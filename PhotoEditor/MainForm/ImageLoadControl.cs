using System.Threading;
using System.Windows.Forms;

namespace PhotoEditor
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Opens dialog window to choose image and 
        /// prepares main form for image load
        /// </summary>
        private void OpenNewImage()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All Images|*.jpg;*.bmp;*.png";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ResetSettings();
                string filename = dialog.FileName;
                Thread thr = new Thread(LoadNewImage);
                thr.Start(filename);
            }
            log.Add("Image opened");
        }

        /// <summary>
        /// Loads new image, prepares thumnails and 
        /// shows everything in the main form
        /// </summary>
        /// <param name="data">Image file name (from parallel thread runner)</param>
        private void LoadNewImage(object data)
        {
            string filename = data.ToString();
            imageSet.Load(
                filename,
                pictureBox2.Width,
                pictureBox2.Height,
                button3.Width - 26,
                button3.Height - 10
            );
            RedrawImageSet();
        }
    }
}
