using System;
using System.Collections.Generic;
using System.Text;
using atmframework_swtgrp9.Interfaces;

namespace atmframework_swtgrp9
{
    public class AirplaneInfo : IAirplaneInfo
    {

        private double course;

        public AirplaneInfo()
        {
            
        }

        public string Tag { get; set; }

        public int X { get; set; }

        public int Y{ get; set; }

        public double Altitude { get; set; }
        public double Course { get => course; set => course = value % 360; }
        public double Velocity { get; set; }

        public DateTime TimeStamp { get; set; }
        

        public void SetAirplaneInfo(string tag, int x, int y, int z, DateTime time)
        {
            Tag = tag;
            X = x;
            Y = y;
            Altitude = z;
            TimeStamp = time;
        }
        
        public override string ToString()
        {
            return Tag + " " +
                   X + " " +
                   Y + " " +
                   Altitude + " " +
                   Math.Round(Velocity, 1) + " m/s " +
                   Math.Round(Course, 1) + "d " +
                   TimeStamp.ToString("dd/MM/yyyy HH:mm:ss");
        }
    }
}
