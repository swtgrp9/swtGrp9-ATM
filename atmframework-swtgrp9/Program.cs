using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using atmframework_swtgrp9.Interfaces;
using TransponderReceiver;

namespace atmframework_swtgrp9
{
    class Program
    {
        static void Main(string[] args)
        {
            var receive = TransponderReceiverFactory.CreateTransponderDataReceiver();


            string logpath = ($"{Environment.CurrentDirectory}/SeparationLog.txt");
            FileLogger file = new FileLogger(logpath);

            AirTrafficMonitor ATM = new AirTrafficMonitor(file, new ConsoleLogger(), new CollisionDetector(file), new Airspace(), new AirplaneGenerator());
        }
    }
}
