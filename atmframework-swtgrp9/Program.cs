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


            FileLogger logpath = new FileLogger($"{Environment.CurrentDirectory}/SeparationLog.txt");

            AirTrafficMonitor ATM = new AirTrafficMonitor(logpath, new ConsoleLogger(), new CollisionDetector(logpath), new Airspace(), new AirplaneGenerator());

            TransponderReceiverClient client = new TransponderReceiverClient(ATM.OnEvent, TransponderReceiverFactory.CreateTransponderDataReceiver());

            while (true)
            {
                Thread.Sleep(1000);
            }
        }

    }
}

