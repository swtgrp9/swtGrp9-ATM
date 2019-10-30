﻿using System;
using System.Collections.Generic;
using System.Text;
using ATM.Core.Interfaces;

namespace ATM.Core
{
    public class AirplaneInfo : IAirplaneInfo
    {

        private double course;

        public AirplaneInfo() { }

        public string aTag { get; set; }

        public int X { get; set; }

        public int Y{ get; set; }

        public double Altitude { get; set; }

        public double Velocity { get; set; }

        public DateTime TimeStamp { get; set; }
        
        public double Course { get => course; set => course = value % 360; }

        public override string ToString()
        {
            return aTag + " " +
                   X + " " +
                   Y + " " +
                   Altitude + " " +
                   Math.Round(Velocity, 1) + " m/s" +
                   Math.Round(Course, 1) + " degrees" +
                   TimeStamp.ToString("dd/mm/yyyy hh:mm:ss");

        }
    }
}
