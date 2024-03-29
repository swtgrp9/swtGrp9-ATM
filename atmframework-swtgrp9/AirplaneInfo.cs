﻿using System;
using System.Collections.Generic;
using System.Text;
using atmframework_swtgrp9.Interfaces;

namespace atmframework_swtgrp9
{
    public class AirplaneInfo : IAirplaneInfo
    {
        
        public AirplaneInfo()
        {
            
        }

        public string Tag { get; set; }

        public int X { get; set; }

        public int Y{ get; set; }

        public double Altitude { get; set; }
        public double Course { get; set; }
        public double Velocity { get; set; }

        public DateTime TimeStamp { get; set; }
        

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
