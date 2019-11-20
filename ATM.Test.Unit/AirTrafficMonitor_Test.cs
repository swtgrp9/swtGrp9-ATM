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
using NSubstitute.ReceivedExtensions;
using NUnit.Framework;
using static NUnit.Framework.Assert;
using Decoder = System.Text.Decoder;

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
       // private string _path;

        //private List<Decoder> _fDecoder;
        //private RawTransponderDataEventArgs _fEventArgs;
        //private Dictionary<string, AirplaneInfo> _faAirplaneInfo; //Skulle gerne kategorisere informationen i alfabetisk rækkefølge

        //Unit under test
        private AirTrafficMonitor _uut;

        [SetUp]
        public void Setup()
        {
            // Arrange
            // (subs)
            _fAirspace = Substitute.For<Airspace>();
            _fGenerator = Substitute.For<AirplaneGenerator>();
            _fDetector = Substitute.For<ICollisionDetector>(/*new FileLogger(_path)*/);
            _fConsoleLogger = Substitute.For<ConsoleLogger>();
            _fFileLogger = Substitute.For<ILog>();
            _fTransponderReceiver = Substitute.For<ITransponderReceiver>();
           // _path = $"{Environment.CurrentDirectory}/log.txt";

            _uut = new AirTrafficMonitor(
                _fAirspace,
                _fGenerator,
                _fFileLogger,
                _fConsoleLogger,
                _fDetector);

        }

        

        [Test]
        public void validAirplane() //Accepterer et fly med alle de korrekte værdier
        {
            var bla = _fGenerator.Generate("SAS321;12312;12312;10000;20190319123456788");

            _uut.AcceptAirplane(bla);

            _fDetector.Register(_fAirspace.GetAirplanes());

            
            Assert.That(_fAirspace.GetAirplanes().Contains(bla));
        }

        [Test]
        public void invalidAirlane() //Accepterer ikke et fly hvis der er forkerte værdier
        {
            var blabla = _fGenerator.Generate("SAS321;12312;12312;30000;20190319123456788");

            _uut.AcceptAirplane(blabla);

            _fDetector.Register(_fAirspace.GetAirplanes());

            Assert.That(!_fAirspace.GetAirplanes().Contains(blabla));

        }


        //[Test]
        //public void AddAirplanes()
        //{
        //   // IAirspace aSpace = new Airspace();

        //    AirplaneInfo info1 = new AirplaneInfo();
        //    AirplaneInfo info2 = new AirplaneInfo();

        //    info1.Tag = "ABC123";
        //    info2.Tag = "123ABC";

            //aSpace.Add(info1);
            //aSpace.Add(info2);

            //Assert.That(aSpace.GetAirplanes().Count, Is.EqualTo(2));
        //}

        //[Test]
        //public void AddMoreAirplanes()
        //{
        //    IAirspace aSpace = new Airspace();

        //    AirplaneInfo info1 = new AirplaneInfo();
        //    AirplaneInfo info2 = new AirplaneInfo();
        //    AirplaneInfo info3 = new AirplaneInfo();
        //    AirplaneInfo info4 = new AirplaneInfo();
        //    AirplaneInfo info5 = new AirplaneInfo();
        //    AirplaneInfo info6 = new AirplaneInfo();
        //    AirplaneInfo info7 = new AirplaneInfo();
        //    AirplaneInfo info8 = new AirplaneInfo();
        //    AirplaneInfo info9 = new AirplaneInfo();
        //    AirplaneInfo info10 = new AirplaneInfo();

        //    info1.Tag = "ABC123";
        //    info2.Tag = "123ABC";
        //    info3.Tag = "XYZ123";
        //    info4.Tag = "123XYZ";
        //    info5.Tag = "NNN123";
        //    info6.Tag = "123NNN";
        //    info7.Tag = "KKK123";
        //    info8.Tag = "123KKK";
        //    info9.Tag = "OOO123";
        //    info10.Tag = "123OOO";

        //    aSpace.Add(info1);
        //    aSpace.Add(info2);
        //    aSpace.Add(info3);
        //    aSpace.Add(info4);
        //    aSpace.Add(info5);
        //    aSpace.Add(info6);
        //    aSpace.Add(info7);
        //    aSpace.Add(info8);
        //    aSpace.Add(info9);
        //    aSpace.Add(info10);

        //    Assert.That(aSpace.GetAirplanes().Count, Is.EqualTo(10));
        //}


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
        //[Test]
        //public void Validate()
        //{
        //    IAirspace aSpace = new Airspace();

        //    AirplaneInfo a1 = new AirplaneInfo
        //    {
        //        Tag = "SAS213",
        //        X = 15000,
        //        Y = 13000,
        //        Altitude = 10001
        //    };

        //    _uut.AcceptAirplane(a1);

        //    Assert.That(aSpace.GetAirplanes().Count, Is.EqualTo(1));
        //}

        //[Test]
        //public void NoValidate()
        //{
        //    IAirspace aSpace = new Airspace();

        //    List<string> testData = new List<String>
        //    {
        //        "SAS321;12312;12312;30000;20190319123456789"
        //    };
            
        //    //testdata = new AirplaneInfo
        //    //{
        //    //    Tag = "SAS321",
        //    //    X = 12312,
        //    //    Y = 12312,
        //    //    Altitude = 1000000000000
        //    //};

        //    _uut.OnEvent(testData);

            
        //    Assert.That(_fAirspace.GetAirplanes().Count, Is.EqualTo(0));

        //   // Assert.That(aSpace.GetAirplanes().Count, Is.EqualTo(0));
        //}


    }
}
