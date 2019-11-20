using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            _fAirspace = Substitute.For<IAirspace<IAirplaneInfo>>();
            _fGenerator = Substitute.For<AirplaneGenerator>();
            _fDetector = Substitute.For<ICollisionDetector>(/*new FileLogger(_path)*/);
            _fConsoleLogger = Substitute.For<ILog>();
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



        //[Test]
        //public void validAirplane() //Accepterer et fly med alle de korrekte værdier
        //{
        //IAirspace<IAirplaneInfo> aspace = new Airspace();
        //IAirplaneGenerator gen = new AirplaneGenerator();
        //I


    //    var bla = gen.Generate("SAS321;12312;12312;10000;20190319123456788");

    //    _uut.AcceptAirplane(bla);

    //    _fDetector.Register(aspace.GetAirplanes());


    //    Assert.That(aspace.GetAirplanes().Contains(bla));
    //}

    //[Test]
    //    public void invalidAirlane() //Accepterer ikke et fly hvis der er forkerte værdier
    //    {
    //        IAirspace<IAirplaneInfo> aspace = new Airspace();
    //        IAirplaneGenerator gen = new AirplaneGenerator();
    //        ICollisionDetector det = new CollisionDetector();

    //        var blabla = _fGenerator.Generate("SAS321;12312;12312;30000;20190319123456788");

    //        _uut.AcceptAirplane(blabla);

    //        _fDetector.Register(_fAirspace.GetAirplanes());

    //        Assert.That(!_fAirspace.GetAirplanes().Contains(blabla));

    //    }


        

        [Test]
        public void PleaseWork()
        {
            var ooga1 = _fGenerator.Generate("SAS321;12312;12312;30000;20190319123456788");

            var ooga = new AirplaneInfo();

            ooga.Tag = "SAS123";
            ooga.X = 10001;
            ooga.Y = 10002;
            ooga.Altitude = 10003;
            ooga.TimeStamp = new DateTime(2019, 01, 01, 01, 01, 01, 111);

            var testList = new List<IAirplaneInfo>();

            testList.Add(ooga);

            _fDetector.GetConditions().Returns(new List<SeparationCondition>());
            _fAirspace.GetAirplanes().Returns(testList);

            _uut.OnEvent(new List<string>());

            _fConsoleLogger.Received().Logs(LOGTYPE.AIRSPACE, Arg.Is<List<string>>( x => x.Count == 1));

        }

        [Test]
        public void PleaseWork2()
        {
            
            var ooga = new AirplaneInfo();

            ooga.Tag = "SAS123";
            ooga.X = 10001;
            ooga.Y = 99999;
            ooga.Altitude = 10003;
            ooga.TimeStamp = new DateTime(2019, 01, 01, 01, 01, 01, 111);

            var testList = new List<IAirplaneInfo>();

            testList.Add(ooga);

            _fDetector.GetConditions().Returns(new List<SeparationCondition>());
            _fAirspace.GetAirplanes().Returns(testList);

            _uut.OnEvent(new List<string>());

            _fConsoleLogger.Received().Logs(LOGTYPE.AIRSPACE, Arg.Is<List<string>>(x => x.Count == 1));

        }

        [Test]
        public void PleaseWork3()
        {
           
            var ooga = new AirplaneInfo();

            ooga.Tag = "SAS123";
            ooga.X = 10001;
            ooga.Y = 10002;
            ooga.Altitude = 10003;
            ooga.TimeStamp = new DateTime(2019, 01, 01, 01, 01, 01, 111);

            var testList = new List<IAirplaneInfo>();

            testList.Add(ooga);


            _fDetector.GetConditions().Returns(new List<SeparationCondition>());
            _fAirspace.GetAirplanes().Returns(testList);
            

            _uut.AcceptAirplane(ooga);

            Assert.That(_fAirspace.GetAirplanes().Contains(ooga));

            //_fConsoleLogger.Received().Logs(LOGTYPE.AIRSPACE, Arg.Is<List<string>>(x => x.Count == 1));

        }

        //[Test]
        //public void PleaseWork4()
        //{

        //    var ooga = new AirplaneInfo();

        //    ooga.Tag = "SAS123";
        //    ooga.X = 10001;
        //    ooga.Y = 10002;
        //    ooga.Altitude = 30000;
        //    ooga.TimeStamp = new DateTime(2019, 01, 01, 01, 01, 01, 111);

        //    var testList = new List<IAirplaneInfo>();

        //    testList.Add(ooga);


        //    _fDetector.GetConditions().Returns(new List<SeparationCondition>());
        //    _fAirspace.GetAirplanes().Returns(testList);


        //    _uut.AcceptAirplane(ooga);

        //    Assert.That(!_fAirspace.GetAirplanes().Contains(ooga));

        //    //_fConsoleLogger.Received().Logs(LOGTYPE.AIRSPACE, Arg.Is<List<string>>(x => x.Count == 1));

        //}



    }
}
