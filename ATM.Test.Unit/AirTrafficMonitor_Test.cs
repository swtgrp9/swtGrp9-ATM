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
using NSubstitute.Core;
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

        [Test]
        public void AddMoreAirplanes()
        {
            IAirspace aSpace = new Airspace();

            AirplaneInfo info1 = new AirplaneInfo();
            AirplaneInfo info2 = new AirplaneInfo();
            AirplaneInfo info3 = new AirplaneInfo();
            AirplaneInfo info4 = new AirplaneInfo();
            AirplaneInfo info5 = new AirplaneInfo();
            AirplaneInfo info6 = new AirplaneInfo();
            AirplaneInfo info7 = new AirplaneInfo();
            AirplaneInfo info8 = new AirplaneInfo();
            AirplaneInfo info9 = new AirplaneInfo();
            AirplaneInfo info10 = new AirplaneInfo();

            info1.Tag = "ABC123";
            info2.Tag = "123ABC";
            info3.Tag = "XYZ123";
            info4.Tag = "123XYZ";
            info5.Tag = "NNN123";
            info6.Tag = "123NNN";
            info7.Tag = "KKK123";
            info8.Tag = "123KKK";
            info9.Tag = "OOO123";
            info10.Tag = "123OOO";

            aSpace.Add(info1);
            aSpace.Add(info2);
            aSpace.Add(info3);
            aSpace.Add(info4);
            aSpace.Add(info5);
            aSpace.Add(info6);
            aSpace.Add(info7);
            aSpace.Add(info8);
            aSpace.Add(info9);
            aSpace.Add(info10);

            Assert.That(aSpace.GetAirplanes().Count, Is.EqualTo(10));
        }


        //[Test] //Test om den kan genkende hvis et fly bliver registreret 2 gange
        //public void CompareFlightsTrue()
        //{
        //    IAirspace aSpace = new Airspace();


        //    IAirplaneInfo info1 = new AirplaneInfo();
        //    IAirplaneInfo info2 = new AirplaneInfo();

        //    info1.Tag = "ABC123";
        //    info1.X = 95000;
        //    info1.Y = 31000;
        //    info1.Altitude = 6000;
        //    info1.TimeStamp = DateTime.Today;

        //    info2.Tag = "ABC123";
        //    info2.X = 95000;
        //    info2.Y = 31000;
        //    info2.Altitude = 6000;
        //    info2.TimeStamp = DateTime.Today;

        //    Assert.That(info1.Equals(info2), Is.True);
        //}

        //[Test] //Test at den kan kende forskel på to fly med forskellige værdier
        //public void CompareFlightsFalse()
        //{
        //    IAirspace aSpace = new Airspace();


        //    AirplaneInfo info1 = new AirplaneInfo();
        //    AirplaneInfo info2 = new AirplaneInfo();

        //    info1.Tag = "ABC123";
        //    info1.X = 95000;
        //    info1.Y = 31000;
        //    info1.Altitude = 6000;
        //    info1.TimeStamp = DateTime.Now;

        //    info2.Tag = "ABC123";
        //    info1.X = 96000;
        //    info1.Y = 31000;
        //    info1.Altitude = 6000;
        //    info1.TimeStamp = DateTime.Now;

        //    Assert.That(info1.Tag.Equals(info2.Tag), Is.False);
        //}


        //Virker men accepterer begge fly
        [TestCase(10001, 1, TestName = "valid airplane")]
        //[TestCase(1000000, 0, TestName = "Invalid airplane")]
        public void Validate(int Valid, int result)
        {
            IAirspace aSpace = new Airspace();

            AirplaneInfo a1 = new AirplaneInfo();
            //AirplaneInfo a2 = new AirplaneInfo();

            a1.Tag = "SAS213";
            a1.X = 10001;
            a1.Y = 13000;
            a1.Altitude = Valid;

            //a2.Tag = "SAS321";
            //a2.X = 15000;
            //a2.Y = 14000;
            //a2.Altitude = Valid;

            aSpace.Add(a1);
            //aSpace.Add(a2);



            //List<string> testData = new List<string>()
            //{
            //    $"SAS123;10001;13000;{Valid};20191101120513900",
            //};

            //_uut.OnEvent(testData);

            Assert.That(aSpace.GetAirplanes().Count, Is.EqualTo(result));
        }

        [TestCase(1000000, 0, TestName = "Invalid airplane")]
        public void NoValidate(int Valid, int result)
        {
            IAirspace aSpace = new Airspace();


            List<string> testData = new List<string>()
            {
                $"SAS123;10001;13000;{Valid};20191101120513900",
            };

            aSpace.Add(testData);

            _uut.OnEvent(testData);

            Assert.That(aSpace.GetAirplanes().Count, Is.EqualTo(result));
        }


    }
}
