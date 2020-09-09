using System;
using System.IO;

namespace PhotoEditor
{
    /// <summary>
    /// Base logger
    /// </summary>
    public class Log
    {
        /// <summary>
        /// Log file path
        /// </summary>
        private string path = "main.log";

        /// <summary>
        /// Time format in log file
        /// </summary>
        private string timeFormat = "yyyy-MM-dd HH-mm-ss";

        /// <summary>
        /// ID of next log file row
        /// </summary>
        private int counter;

        /// <summary>
        /// Initialize new log file or continue logging inside existing log file
        /// </summary>
        public Log()
        {
            counter = 1;
            if (File.Exists(path))
            {
                Add("******", DateTime.Now.ToString(timeFormat), "App launched");
            }
            else
            {
                StreamWriter sw = new StreamWriter(path);
                sw.WriteLine("************************************");
                sw.WriteLine("Welcome to the PhotoEditor log file!");
                sw.WriteLine(" App launched - " + DateTime.Now.ToString(timeFormat));
                sw.WriteLine("************************************");
                sw.Close();
            }
        }

        /// <summary>
        /// Entry point to log addition
        /// </summary>
        /// <param name="message">Log message</param>
        public void Add(string message)
        {
            Add(counter.ToString("D6"), DateTime.Now.ToString(timeFormat), message);
            ++counter;
        }

        /// <summary>
        /// Log addition and formating
        /// </summary>
        /// <param name="id">Log identificator</param>
        /// <param name="time">Time of addition</param>
        /// <param name="message">Log message</param>
        private void Add(string id, string time, string message)
        {
            File.AppendAllText(path, id + " - " + time + " - " + message + Environment.NewLine);
        }
    }
}
