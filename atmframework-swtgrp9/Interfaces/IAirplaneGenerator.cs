using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Core.Interfaces
{
    public interface IAirplaneGenerator
    {
        IAirplaneInfo Generate(string planeData);
    }
}
