﻿using System;
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
using static NUnit.Framework.Assert;
using Decoder = System.Text.Decoder;

namespace ATM.Test.Unit
{
    [TestFixture]
    class AirTrafficMonitor_Test
    {
        //Fakes
        private IAirspace _fAirspace;
        private IAirplaneGenerator _fGenerator;
        private ICollisionDetector _fDetector;
        private ILog _fConsoleLogger;
        private ILog _fFileLogger;
        private ITransponderReceiver _fTransponderReceiver;

        private List<Decoder> _fDecoder;
        private RawTransponderDataEventArgs _fEventArgs;
        private Dictionary<string, AirplaneInfo> _faAirplaneInfo; //Skulle gerne kategorisere informationen i alfabetisk rækkefølge


        //Unit under test
        private AirTrafficMonitor _uut;

        [SetUp]
        public void Setup()
        {
            // Arrange
            // (subs)
            _fAirspace = Substitute.For<IAirspace>();
            _fGenerator = Substitute.For<IAirplaneGenerator>();
            _fDetector = Substitute.For<ICollisionDetector>();
            _fConsoleLogger = Substitute.For<ILog>();
            _fFileLogger = Substitute.For<ILog>();
            _fTransponderReceiver = Substitute.For<ITransponderReceiver>();

            _uut = new AirTrafficMonitor(
                _fFileLogger,
                _fConsoleLogger,
                _fDetector,
                _fAirspace,
                _fGenerator);

        }

        [Test]
        public void AddAirplanes()
        {
            IAirspace aSpace = new Airspace();

            AirplaneInfo info1 = new AirplaneInfo();
            AirplaneInfo info2 = new AirplaneInfo();

            info1.Tag = "ABC123";
            info2.Tag = "123ABC";

            aSpace.Add(info1);
            aSpace.Add(info2);

            Assert.That(aSpace.GetAirplanes().Count, Is.EqualTo(2));
        }

    }
}
