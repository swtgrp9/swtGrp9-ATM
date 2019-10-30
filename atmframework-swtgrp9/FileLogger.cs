using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using atmframework_swtgrp9.Interfaces;

namespace ATM.Core
{
    public class FileLogger : ILog
    {
        private string logpath;

        public FileLogger(string path)
        {
            logpath = path;
        }

        public void Logs(LOGTYPE type, List<string> logMessages)
        {
            //Kun collisions
            if (type != LOGTYPE.COLLISIONS) return;

            StreamWriter sw = File.AppendText(logpath);

            for (int i = 0; i < logMessages.Count; i++)
            {
                sw.WriteLine(logMessages[i]);
            }

            sw.Close();
        }

    }
}
