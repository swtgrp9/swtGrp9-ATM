using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using atmframework_swtgrp9;
using atmframework_swtgrp9.Interfaces;
using TransponderReceiver;

namespace atmframework_swtgrp9
{
    class Program
    {
        private static void Main(string[] args)
        {
            var receive = TransponderReceiverFactory.CreateTransponderDataReceiver();


            FileLogger logpath = new FileLogger($"{Environment.CurrentDirectory}/SeparationLog.txt");
            //FileLogger file = new FileLogger(logpath);

            AirTrafficMonitor ATM = new AirTrafficMonitor(logpath, new ConsoleLogger(), new CollisionDetector(logpath), new Airspace(), new AirplaneGenerator());

            while (true)
            {
                Thread.Sleep(1000);
            }
        }

    }
}

