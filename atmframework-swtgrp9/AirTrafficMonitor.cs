﻿using System;
using System.Collections.Generic;
using System.Text;
using TransponderReceiver;
using atmframework_swtgrp9.Interfaces;

namespace atmframework_swtgrp9
{
    public class AirTrafficMonitor
    {
        private IAirspace<IAirplaneInfo> _airspace;
        private IAirplaneGenerator _generator;
        private ILog _fileLog;
        private ILog _consoleLog;
        private ICollisionDetector _collision;

        public AirTrafficMonitor(
            IAirspace<IAirplaneInfo> airspace,
            IAirplaneGenerator generator,
            ILog fileLog,
            ILog consoleLog,
            ICollisionDetector register
        )

        {
            _airspace = airspace;
            _generator = generator;
            _fileLog = fileLog;
            _consoleLog = consoleLog;
            _collision = register;
        }

        public void OnEvent(List<string> flightData)
        {
            foreach (var f in flightData)
            {
                var plane = _generator.Generate(f);

                AcceptAirplane(plane);

                _collision.Register(_airspace.GetAirplanes());
            }
            PrintAirspace();
            PrintCollisions();
        }

        public void AcceptAirplane(IAirplaneInfo airplane)
        {
            int Xmin = _airspace.GetX1();
            int Xmax = _airspace.GetX2();
            int Ymin = _airspace.GetY1();
            int Ymax = _airspace.GetY2();
            int Zmin = _airspace.GetAlt1();
            int Zmax = _airspace.GetAlt2();

            if (airplane.X < Xmin || airplane.X > Xmax ||
                airplane.Y < Ymin || airplane.Y > Ymax ||
                airplane.Altitude < Zmin || airplane.Altitude > Zmax)
            {
                _airspace.Remove(airplane);
            }
            else
            {
                _airspace.Add(airplane);
            }
        }

        private void PrintAirspace()
        {
            var planes = _airspace.GetAirplanes();
            var logMessages = new List<string>();

            foreach (var airplane in planes)
            {
                logMessages.Add(airplane.ToString());
            }
            _consoleLog.Logs(LOGTYPE.AIRSPACE, logMessages);
        }

        private void PrintCollisions()
        {
            var conditions = _collision.GetConditions();
            var logMessages = new List<string>();

            foreach (var condition in conditions)
            {
                var logmsg =
                    $"{condition.Time:dd/MM/yyyy HH:mm:ss} {condition.PairAirplanes.Item1.Tag} {condition.PairAirplanes.Item2.Tag}";
                logMessages.Add(logmsg);
            }

            _consoleLog.Logs(LOGTYPE.COLLISIONS, logMessages);
        }

    }
}
