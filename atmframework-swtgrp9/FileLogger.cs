using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using atmframework_swtgrp9.Interfaces;

namespace atmframework_swtgrp9
{
    public class FileLogger : ILog
    {
        private string _logpath;

        public FileLogger(string path)
        {
            _logpath = path;
        }

        public void Logs(LOGTYPE type, List<string> logMessages)
        {
            //Kun collisions
            if (type != LOGTYPE.COLLISIONS) return;

            StreamWriter sw = File.AppendText(_logpath);

            for (int i = 0; i < logMessages.Count; i++)
            {
                sw.WriteLine(logMessages[i]);
            }

            sw.Close();
        }

    }
}
