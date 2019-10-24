using System;
using System.Collections.Generic;
using System.Text;
using ATM.Core.Interfaces

namespace ATM.Core
{
    public class AirplaneInfo : IAirplaneInfo
    
    {
        public string Tag { get; set; }

        public double Xcoordinate { get; set; }

        public double Ycoordinate { get; set; }

        public double Altitude { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
