using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoEditor
{
    public partial class Form1 : Form
    {
        private readonly Color toolGrey = Color.FromArgb(36, 36, 36);
        private readonly Color pictureGrey = Color.FromArgb(42, 42, 42);
        public Button active;

        public Form1()
        {
            InitializeComponent();
            active = button3;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Left = Top = 0;
            Width = Screen.PrimaryScreen.WorkingArea.Width;
            Height = Screen.PrimaryScreen.WorkingArea.Height;
            panel2.Width = Width / 4;
            panel2.Location = new Point(Width - panel2.Width, 30);
            int newPreviewWidth = 3 * Width / 16;
            int newPreviewHeight = (Height - 30) / 5;
            Button[] buttons = { button3, button4, button5, button6 };
            for (int i = 0; i < 4; ++i)
            {
                buttons[i].Width = newPreviewWidth;
                buttons[i].Height = newPreviewHeight;
                buttons[i].Location = new Point(newPreviewWidth * i, Height - newPreviewHeight);
            }
            pictureBox2.Width = Width - panel2.Width - 20;
            pictureBox2.Height = Height - newPreviewHeight - 50;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void ChangePreview(Button button)
        {
            active.BackColor = toolGrey;
            active.Refresh();
            active = button;
            active.BackColor = pictureGrey;
            active.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChangePreview(button3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChangePreview(button4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ChangePreview(button5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ChangePreview(button6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panel5.Visible = false;
            panel3.Visible = !panel3.Visible;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // Open (change cursor)
            panel3.Visible = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // Save (change cursor)
            panel3.Visible = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            // Save as... (change cursor)
            panel3.Visible = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            // Multiple apply (change cursor)
            panel3.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel5.Visible = false;
            panel4.Visible = !panel4.Visible;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            // Undo
            panel4.Visible = false;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            // Redo
            panel4.Visible = false;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            // Export LUT
            panel4.Visible = false;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            // Settings
            panel4.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = !panel5.Visible;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            // User manual
            panel5.Visible = false;
            string targetURL = @"https://github.com/MartinStevko/PhotoEditor/wiki/User-manual";
            System.Diagnostics.Process.Start(targetURL);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            // Dosumentation
            panel5.Visible = false;
            string targetURL = @"https://github.com/MartinStevko/PhotoEditor/wiki/Documentation";
            System.Diagnostics.Process.Start(targetURL);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            // Report issue
            panel5.Visible = false;
            string targetURL = @"https://github.com/MartinStevko/PhotoEditor/issues/new/choose";
            System.Diagnostics.Process.Start(targetURL);
        }
    }
}
