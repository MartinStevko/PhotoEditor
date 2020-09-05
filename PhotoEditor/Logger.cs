using System;
using System.IO;

namespace PhotoEditor
{
    public class Log
    {
        private string path = "main.log";

        private string timeFormat = "yyyy-MM-dd HH-mm-ss";

        private int counter;

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

        public void Add(string message)
        {
            Add(counter.ToString("D6"), DateTime.Now.ToString(timeFormat), message);
            ++counter;
        }

        private void Add(string id, string time, string message)
        {
            File.AppendAllText(path, id + " - " + time + " - " + message + Environment.NewLine);
        }
    }
}