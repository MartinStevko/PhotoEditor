using System;
using System.Windows.Forms;

namespace PhotoEditor
{
    /// <summary>
    /// Main form - help menu events
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Show app menu under 'Help' - User manual, Documentation, Report issue
        /// </summary>
        private void HelpMenuButtonClick(object sender, EventArgs e)
        {
            bool state = !helpPanel.Visible;
            CloseAllPopUps();
            helpPanel.Visible = state;
        }

        /// <summary>
        /// Help -> User manual menu button - opens user manual in user default web browser
        /// </summary>
        private void ManualButtonClick(object sender, EventArgs e)
        {
            helpPanel.Visible = false;
            string targetURL = @"https://github.com/MartinStevko/PhotoEditor/wiki/User-manual";
            System.Diagnostics.Process.Start(targetURL);
            log.Add("User manual opened");
        }

        /// <summary>
        /// Help -> Documentation menu button - opens program documentation in user default web browser
        /// </summary>
        private void DocumentationButtonClick(object sender, EventArgs e)
        {
            helpPanel.Visible = false;
            string targetURL = @"https://github.com/MartinStevko/PhotoEditor/wiki/Documentation";
            System.Diagnostics.Process.Start(targetURL);
            log.Add("Program documentation opened");
        }

        /// <summary>
        /// Help -> Report issue menu button - opens report issue website in user default web browser
        /// </summary>
        private void IssueButtonClick(object sender, EventArgs e)
        {
            helpPanel.Visible = false;
            string targetURL = @"https://github.com/MartinStevko/PhotoEditor/issues/new/choose";
            System.Diagnostics.Process.Start(targetURL);
            log.Add("Report issue form opened");
        }
    }
}
