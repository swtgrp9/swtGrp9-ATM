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

        
        public double CalcVelocity(IAirplaneInfo current, IAirplaneInfo previous)
        {
            var distance = Math.Sqrt(Math.Pow(current.X - previous.X, 2) + Math.Pow(current.Y - previous.Y, 2));
            var timeDifference = (current.TimeStamp - previous.TimeStamp).TotalSeconds;
            var totalVelocity = distance / timeDifference;
            return totalVelocity;
        }

        public double CalcCourse(IAirplaneInfo current, IAirplaneInfo previous)
        {
            var Theta = Math.Atan2(previous.Y - current.Y, previous.X - current.X);
            Theta += Math.PI / 2;
            var Angle = Theta * (180 / Math.PI);
            if (Angle < 0)
            {
                Angle += 360;
            }
            return Angle;
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
                TimeStamp = m.Time,
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
