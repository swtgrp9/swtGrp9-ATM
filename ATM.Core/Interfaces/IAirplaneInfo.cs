using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Core.Interfaces
{
    public interface IAirplaneInfo
    {
        string Tag { get; set; }

        double Xcoordinate { get; set; }

        double Ycoordinate { get; set; }

        double Altitude { get; set; }

        DateTime Timestamp { get; set; }
    }

}