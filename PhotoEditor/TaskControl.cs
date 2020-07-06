using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace PhotoEditor
{
    class TaskControl
    {
        private MainForm form;

        private ImageTask head;
        private ImageTask tail;

        private ImageTask headWaiting;
        private ImageTask tailWaiting;

        public Queue undoQueue;
        public Queue redoQueue;

        public TaskControl(MainForm form)
        {
            this.form = form;

            head = null;
            tail = null;

            headWaiting = null;
            tailWaiting = null;

            undoQueue = new Queue();
            redoQueue = new Queue();

            Thread t = new Thread(Process);
            t.IsBackground = true;
            t.Start();
        }

        public void Add(ImageTask task)
        {
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

        private void Process()
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

                head.Process(form.imageSet);
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
            Process();
        }

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
