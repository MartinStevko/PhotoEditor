using System.Collections.Generic;
using System.Threading;

namespace PhotoEditor
{
    /// <summary>
    /// Control engine for image set processors
    /// </summary>
    class TaskControl
    {
        #region Task control variables

        /// <summary>
        /// Pointer to main app form
        /// </summary>
        private MainForm form;

        /// <summary>
        /// Head of linked list of image tasks
        /// </summary>
        private ImageTask head;
        /// <summary>
        /// Tail of linked list of image tasks
        /// </summary>
        private ImageTask tail;

        /// <summary>
        /// Head of linked list of image tasks waiting for execution
        /// </summary>
        private ImageTask headWaiting;
        /// <summary>
        /// Tail of linked list of image tasks waiting for execution
        /// </summary>
        private ImageTask tailWaiting;

        /// <summary>
        /// Circle queue of restore points of image set in app
        /// Handles states BEFORE current state
        /// </summary>
        public Queue undoQueue;
        /// <summary>
        /// Circle queue of restore points of image set in app
        /// Handles states AFTER current state
        /// </summary>
        public Queue redoQueue;

        /// <summary>
        /// All tasks done to the image set
        /// </summary>
        public Stack<ImageTask> tasks;
        /// <summary>
        /// All undone tasks done to the image set
        /// </summary>
        public Stack<ImageTask> removed;

        #endregion

        /// <summary>
        /// Initialize task control variables to defaults and 
        /// starts parallel thread for image processing
        /// </summary>
        /// <param name="form">Pointer to main app form</param>
        public TaskControl(MainForm form)
        {
            this.form = form;

            head = null;
            tail = null;

            headWaiting = null;
            tailWaiting = null;

            undoQueue = new Queue();
            redoQueue = new Queue();

            tasks = new Stack<ImageTask>();
            removed = new Stack<ImageTask>();

            Thread t = new Thread(Process);
            t.IsBackground = true;
            t.Start();
        }

        /// <summary>
        /// Adds image task to the tasks and linked list for image processing
        /// </summary>
        /// <param name="task">Task which should edit image set</param>
        public void Add(ImageTask task)
        {
            tasks.Push(task);
            if ((head == null) || (!head.ongoing))
            {
                if (head == null)
                {
                    head = task;
                    tail = task;
                }
                else
                {
                    if (tail.taskType == task.taskType)
                    {
                        if (tail.previous == null)
                        {
                            head = task;
                            tail = task;
                        }
                        else
                        {
                            tail.previous.next = task;
                            task.previous = tail.previous;
                            tail = task;
                        }
                    }
                    else
                    {
                        tail.next = task;
                        task.previous = tail;
                        tail = task;
                    }
                }
            }
            else
            {
                if (headWaiting == null)
                {
                    headWaiting = task;
                    tailWaiting = task;
                }
                else
                {
                    if (tailWaiting.taskType == task.taskType)
                    {
                        if (tailWaiting.previous == null)
                        {
                            headWaiting = task;
                            tailWaiting = task;
                        }
                        else
                        {
                            tailWaiting.previous.next = task;
                            task.previous = tailWaiting.previous;
                            tailWaiting = task;
                        }
                    }
                    else
                    {
                        tailWaiting.next = task;
                        task.previous = tailWaiting;
                        tailWaiting = task;
                    }
                }
            }
        }

        /// <summary>
        /// Infinite function which calls itself each time it is done
        /// Processes all tasks in main (not waiting) linked list and 
        /// creates restore point to undo queue
        /// </summary>
        private void Process()
        {
            while (true)
            {
                if (head != null)
                {
                    head.ongoing = true;

                    RestorePoint old = new RestorePoint(
                        form.imageSet.imageMode,
                        head.taskType,
                        form.imageSet.image.Clone(form.imageSet.rectangle, form.imageSet.image.PixelFormat),
                        form.imageSet.thumb.Clone(form.imageSet.thumbRectangle, form.imageSet.thumb.PixelFormat),
                        form.imageSet.saturation,
                        form.imageSet.brightness,
                        form.imageSet.clarity
                    );
                    undoQueue.Add(old);
                    redoQueue.Flush();

                    head.Process();
                    head = head.next;
                    if (head != null)
                    {
                        head.previous = null;
                    }
                    form.RedrawImageSet();
                }
                else
                {
                    Thread.Sleep(100);
                }
            }
        }

        /// <summary>
        /// Puts every task from waiting linked list to main linked list
        /// </summary>
        public void CheckAndProcess()
        {
            if (head == null)
            {
                head = headWaiting;
                tail = tailWaiting;
                headWaiting = null;
                tailWaiting = null;
            }
            else if (head.ongoing)
            {
                Thread.Sleep(100);
                CheckAndProcess();
            }
            else
            {
                if (headWaiting != null)
                {
                    tail.next = headWaiting;
                    headWaiting.previous = tail;
                    tail = tailWaiting;
                }
            }
        }
    }
}
