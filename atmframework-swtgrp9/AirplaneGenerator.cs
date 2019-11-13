using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.CodeAnalysis;
using atmframework_swtgrp9.Interfaces;

namespace atmframework_swtgrp9
{
    public class AirplaneGenerator : IAirplaneGenerator
    {
        private readonly Dictionary<string, IAirplaneInfo> PlanesDictionary;
        public AirplaneGenerator()
        {
            PlanesDictionary = new Dictionary<string, IAirplaneInfo>();
        }

        
        public double CalcVelocity(IAirplaneInfo previous, IAirplaneInfo current)
        {
            var distance = Math.Sqrt(Math.Pow(current.X - previous.X, 2) + Math.Pow(current.Y - previous.Y, 2));
            var timeDifference = (current.TimeStamp - previous.TimeStamp).TotalSeconds;
            var totalVelocity = distance / timeDifference;
            return totalVelocity;
        }

        public double CalcCourse(IAirplaneInfo previous, IAirplaneInfo current)
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
            var d = new Decoder(Data);

            IAirplaneInfo airplane = new AirplaneInfo
            {
                Tag = d.AirplaneTag,
                X = d.Xcoordinates,
                Y = d.Ycoordinates,
                Altitude = d.Altitude,
                TimeStamp = d.Time,
            };

            if(PlanesDictionary.ContainsKey(d.AirplaneTag))
            {
                var returningPlane = PlanesDictionary[d.AirplaneTag];

                returningPlane.Velocity = CalcVelocity(returningPlane, airplane);
                returningPlane.Course = CalcCourse(returningPlane, airplane);
                returningPlane.X = airplane.X;
                returningPlane.Y = airplane.Y;
                returningPlane.Altitude = airplane.Altitude;
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
