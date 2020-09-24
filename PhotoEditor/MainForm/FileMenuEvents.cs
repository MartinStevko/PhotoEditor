using System;
using System.Windows.Forms;

namespace PhotoEditor
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Show app menu under 'File' - Open new, Save, Save as..., Multiple apply
        /// </summary>
        private void button7_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panel5.Visible = false;
            panel3.Visible = !panel3.Visible;
        }

        /// <summary>
        /// File -> Open menu button - promt warning if previous image is not saved or open a new image
        /// </summary>
        private void button10_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null)
            {
                panel6.Visible = true;
            }
            else
            {
                panel3.Visible = false;
                OpenNewImage();
            }
        }

        /// <summary>
        /// File -> Open -> Yes, I am sure button - open new image
        /// </summary>
        private void button22_Click(object sender, EventArgs e)
        {
            panel6.Visible = false;
            panel3.Visible = false;
            OpenNewImage();
        }

        /// <summary>
        /// File -> Open -> No, take me back button - hide newly visible components
        /// </summary>
        private void button18_Click(object sender, EventArgs e)
        {
            panel6.Visible = false;
            panel3.Visible = false;
        }

        /// <summary>
        /// File -> Save menu button - saves changes made to the image with origin name
        /// </summary>
        private void button11_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            string file = imageSet.filename;
            pictureBox2.Image.Save(file);
            log.Add("File saved");
        }

        /// <summary>
        /// File -> Save as... menu button - saves chnages made to the object with custom name
        /// </summary>
        private void button12_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "All Images|*.jpg;*.bmp;*.png";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image.Save(dialog.FileName);
            }
            log.Add("File saved as " + dialog.FileName);
        }

        /// <summary>
        /// File -> Import LUT menu button - imports .CUBE file as look-up table
        /// </summary>
        private void button13_Click(object sender, EventArgs e)
        {
            // TODO: Import LUT
            panel3.Visible = false;
        }
    }
}
