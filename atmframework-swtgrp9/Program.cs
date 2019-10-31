using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using atmframework_swtgrp9.Interfaces;

namespace atmframework_swtgrp9
{
    class Program
    {
        static void Main(string[] args)
        {
            string logpath = ($"{Environment.CurrentDirectory}/SeparationLog.txt");
            FileLogger file = new FileLogger(logpath);

            AirTrafficMonitor ATM = new AirTrafficMonitor(file, new ConsoleLogger(), new CollisionDetector(file), new Airspace(), new AirplaneGenerator());
        }
    }
}
