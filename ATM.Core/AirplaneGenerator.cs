using System;
using System.Collections.Generic;
using System.Text;
using ATM.Core.Interfaces;

namespace ATM.Core
{
    public class AirplaneGenerator : IAirplaneGenerator
    {
        public AirplaneGenerator()
        {

        }

        public IAirplaneInfo Generate(string planeData)
        {
            throw new NotImplementedException();
        }

        public double CalcVelocity(IAirplaneInfo ap1, IAirplaneInfo ap2)
        {
            return;
        }

        public double CalcCourse(IAirplaneInfo ap1, IAirplaneInfo ap2)
        {
            return;
        }
    }
}
