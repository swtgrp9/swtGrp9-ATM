using System;
using System.Collections.Generic;
using System.Text;

namespace atmframework_swtgrp9.Interfaces
{
    public interface IAirplaneInfo
    {
        string Tag { get; set; }
        int X { get; set; }
        int Y { get; set; }

        double Altitude { get; set; }

        double Velocity { get; set; }

        double Course { get; set; }

        DateTime TimeStamp { get; set; }
    }
}
