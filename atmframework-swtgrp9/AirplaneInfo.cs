using System;
using System.Collections.Generic;
using System.Text;
using atmframework_swtgrp9.Interfaces;

namespace atmframework_swtgrp9
{
    public class AirplaneInfo : IAirplaneInfo
    {

        private double course;

        public AirplaneInfo() { }

        public string Tag { get; set; }

        public int X { get; set; }

        public int Y{ get; set; }

        public double Altitude { get; set; }

        public double Velocity { get; set; }

        public DateTime Timestamp { get; set; }
        public DateTime TimeStamp { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Course { get => course; set => course = value % 360; }

        public override string ToString()
        {
            return Tag + " " +
                   X + " " +
                   Y + " " +
                   Altitude + " " +
                   Math.Round(Velocity, 1) + " m/s" +
                   Math.Round(Course, 1) + " degrees" +
                   Timestamp.ToString("dd/mm/yyyy hh:mm:ss");

        }
    }
}
