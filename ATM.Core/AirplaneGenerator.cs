using System;
using System.Collections.Generic;
using System.Text;
using ATM.Core.Interfaces;

namespace ATM.Core
{
    public class AirplaneGenerator : IAirplaneGenerator
    {
        private readonly Dictionary<string, IAirplaneInfo> PlanesDictionary;
        public AirplaneGenerator()
        {
            PlanesDictionary = new Dictionary<string, IAirplaneInfo>();
        }

        
        public double CalcVelocity(IAirplaneInfo ap1, IAirplaneInfo ap2)
        {
            return;
        }

        public double CalcCourse(IAirplaneInfo ap1, IAirplaneInfo ap2)
        {
            return;
        }

        public IAirplaneInfo Generate(string Data)
        {
            var m = new Mapper(Data);

            IAirplaneInfo airplane = new AirplaneInfo
            {
                Tag = m.AirplaneTag,
                X = m.Xcoordinates,
                Y = m.Ycoordinates,
                Altitude = m.Altitude,
                Timestamp = m.Time,
            };

            if(PlanesDictionary.ContainsKey(m.AirplaneTag))
            {
                var returningPlane = PlanesDictionary[m.AirplaneTag];

                returningPlane.X = airplane.X;
                returningPlane.Y = airplane.Y;
                returningPlane.Velocity = CalcVelocity(returningPlane, airplane);
                returningPlane.Altitude = airplane.Altitude;
                returningPlane.Course = CalcCourse(returningPlane, airplane);
                returningPlane.TimeStamp = airplane.TimeStamp;

                return returningPlane;

            }
            else
            {
                PlanesDictionary.Add(airplane.Tag, airplane);
            }

            return airplane;
        }
    }
}
