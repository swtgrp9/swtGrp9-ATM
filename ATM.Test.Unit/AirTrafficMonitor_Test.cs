using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using atmframework_swtgrp9;
using atmframework_swtgrp9.Interfaces;
using TransponderReceiver;
using NSubstitute;
using NUnit.Framework;

namespace ATM.Test.Unit
{
    [TestFixture]
    class AirTrafficMonitor_Test
    {
        //Fakes
        private IAirspace<IAirplaneInfo> _fAirspace;
        private IAirplaneGenerator _fGenerator;
        private ICollisionDetector _fDetector;
        private ILog _fConsoleLogger;
        private ILog _fFileLogger;
        private ITransponderReceiver _fTransponderReceiver;


        //Unit under test
        private AirTrafficMonitor _uut;

        [SetUp]
        public void Setup()
        {
            //subs
            _fAirspace = Substitute.For<Airspace>();
            _fGenerator = Substitute.For<AirplaneGenerator>();
            _fDetector = Substitute.For<CollisionDetector>();
            _fConsoleLogger = Substitute.For<ConsoleLogger>();
            _fFileLogger = Substitute.For<FileLogger>();
            _fTransponderReceiver = Substitute.For<ITransponderReceiver>();


        }

    }
}
