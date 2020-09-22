using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using PhotoEditor.Tasks;

namespace PhotoEditor
{
    /// <summary>
    /// Main form - edit menu events
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Show app menu under 'Edit' - Undo, Redo, Export LUT, Settings
        /// </summary>
        private void EditMenuButtonClick(object sender, EventArgs e)
        {
            bool state = !editPanel.Visible;
            CloseAllPopUps(sender, e);
            editPanel.Visible = state;
        }

        /// <summary>
        /// Edit -> Undo menu button - undo last action
        /// </summary>
        private void UndoButtonClick(object sender, EventArgs e)
        {
            editPanel.Visible = false;

            if (taskControl.tasks.Any())
            {
                taskControl.removed.Push(taskControl.tasks.Pop());
            }
            RestorePoint restorePoint = taskControl.undoQueue.RemoveLast();
            if (restorePoint != null)
            {
                RestorePoint old = new RestorePoint(
                    imageSet.imageMode,
                    restorePoint.taskType,
                    imageSet.image.Clone(imageSet.rectangle, imageSet.image.PixelFormat),
                    imageSet.thumb.Clone(imageSet.thumbRectangle, imageSet.thumb.PixelFormat),
                    imageSet.saturation,
                    imageSet.brightness,
                    imageSet.clarity
                );
                taskControl.redoQueue.Add(old);

                ApplyRestorePoint(restorePoint);
                log.Add("Last action was un-done");
            }
            else
            {
                log.Add("Action can not be un-done, there is no actions left in the queue");
            }
        }

        /// <summary>
        /// Edit -> Redo menu button - redo last action if it was undone
        /// </summary>
        private void RedoButtonClick(object sender, EventArgs e)
        {
            editPanel.Visible = false;

            if (taskControl.removed.Any())
            {
                taskControl.tasks.Push(taskControl.removed.Pop());
            }
            RestorePoint restorePoint = taskControl.redoQueue.RemoveLast();
            if (restorePoint != null)
            {
                RestorePoint old = new RestorePoint(
                    imageSet.imageMode,
                    restorePoint.taskType,
                    imageSet.image.Clone(imageSet.rectangle, imageSet.image.PixelFormat),
                    imageSet.thumb.Clone(imageSet.thumbRectangle, imageSet.thumb.PixelFormat),
                    imageSet.saturation,
                    imageSet.brightness,
                    imageSet.clarity
                );
                taskControl.undoQueue.Add(old);

                ApplyRestorePoint(restorePoint);
                log.Add("Last un-done action was re-done");
            }
            else
            {
                log.Add("Action cannot be re-done, there is no other actions in the queue");
            }
        }

        /// <summary>
        /// Determines whether Undo and Redo buttons should be enabled
        /// Use by adding to the end of "RedrawMainImage" method
        /// </summary>
        private void ActionHandlersActive()
        {
            if (taskControl.undoQueue.IsEmpty())
            {
                undoButton.Enabled = false;
                undoButton.Refresh();
            }
            else
            {
                undoButton.Enabled = true;
                undoButton.Refresh();
            }
            if (taskControl.redoQueue.IsEmpty())
            {
                redoButton.Enabled = false;
                redoButton.Refresh();
            }
            else
            {
                redoButton.Enabled = true;
                redoButton.Refresh();
            }
        }

        /// <summary>
        /// Edit -> Export LUT menu button - exports LUT file from changes made onto currently opened image
        /// </summary>
        private void ExportLutButtonClick(object sender, EventArgs e)
        {
            Thread thr = new Thread(ExportLUT);
            thr.Start();
            editPanel.Visible = false;
        }

        /// <summary>
        /// Exports look-up table file
        /// </summary>
        private void ExportLUT()
        {
            string filename = Guid.NewGuid().ToString();
            LookUpTable.Write(filename + ".CUBE", taskControl.tasks);
            log.Add("LUT file exported");
        }

        /// <summary>
        /// Edit -> Apply LUT file menu button - prompts LUT file choice
        /// </summary>
        private void ApplyLutButtonClick(object sender, EventArgs e)
        {
            lutPanel.Visible = lutPanel.Visible == false;
        }

        /// <summary>
        /// Edit -> Apply LUT file -> Apply menu button - applies choosen LUT file
        /// </summary>
        private void ApplyLutConfirmButtonClick(object sender, EventArgs e)
        {
            if (lutComboBox.SelectedItem != null)
            {
                ImageTask task = new ApplyLUT(
                    ImageModification.ApplyLUT,
                    imageSet,
                    lutComboBox.SelectedItem.ToString()
                );
                taskControl.Add(task);
                taskControl.CheckAndProcess();
                log.Add("LUT file applied");
            }
            CloseAllPopUps(sender, e);
        }
    }
}
