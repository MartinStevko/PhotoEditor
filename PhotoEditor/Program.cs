using System;
using System.Windows.Forms;

namespace PhotoEditor
{
    /// <summary>
    /// Application
    /// </summary>
    static class Program
    {
        /// <summary>
        /// The main entry point for the application
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            } 
            catch (Exception e)
            {
                MainForm.log.Add("Error! " + e.Message);
                throw e;
            }
        }
    }
}
