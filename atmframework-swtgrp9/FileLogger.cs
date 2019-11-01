using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using atmframework_swtgrp9.Interfaces;

namespace atmframework_swtgrp9
{
    public class FileLogger : ILog
    {

        public FileLogger()
        {
        }

        public void Logs(LOGTYPE type, List<string> logMessages)
        {
            //Kun collisions
            if (type != LOGTYPE.COLLISIONS) return;

            StreamWriter sw = File.AppendText("log.txt"); //Skriver ny besked hver gang

            for (int i = 0; i < logMessages.Count; i++)//Skriver en advarsel om hver collision til logfilen
            {
                sw.WriteLine(logMessages[i]);
            }

            sw.Close(); //lukker streamwriter efter brug
        }

    }
}
