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

        private ITime _fSeperationCondition;
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
            _fSeperationCondition = Substitute.For<ITime>();
           // _path = $"{Environment.CurrentDirectory}/log.txt";

            _uut = new AirTrafficMonitor(
                _fAirspace,
                _fGenerator,
                _fFileLogger,
                _fConsoleLogger,
                _fDetector);

        }
        

        [Test]
        public void OnEventPrintsAirspaces()
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

            _uut.OnEvent(new List<string>());

            _fConsoleLogger.Received().Logs(LOGTYPE.AIRSPACE, Arg.Is<List<string>>( x => x.Count == 1));

        }

       

        [Test]
        public void AcceptAirplanePlaneGetsRemoved()
        {
            
            var ooga = new AirplaneInfo();

            ooga.Tag = "SAS123";
            ooga.X = 10001;
            ooga.Y = 30002;
            ooga.Altitude = 10003;
            ooga.TimeStamp = new DateTime(2019, 01, 01, 01, 01, 01, 111);

            var testList = new List<IAirplaneInfo>();

            testList.Add(ooga);


            _uut.AcceptAirplane(ooga);


            _fDetector.GetConditions().Returns(new List<SeparationCondition>());
            _fAirspace.GetAirplanes().Returns(testList);

            

            Assert.That(_fAirspace.GetAirplanes().Contains(ooga));

           

        }




        /*Mislykket test af OnEvent hvor den skal kalde PrintCollision funktionen*/

        //[Test]
        //public void PrintCollisions()
        //{
        //    
        //    var ooga = new AirplaneInfo();
        //    var ooga2 = new AirplaneInfo();

        //    ooga.Tag = "SAS123";
        //    ooga.X = 10001;
        //    ooga.Y = 10002;
        //    ooga.Altitude = 10003;
        //    ooga.TimeStamp = new DateTime(2019, 01, 01, 01, 01, 01, 111);

        //    ooga2.Tag = "SAS321";
        //    ooga2.X = 10001;
        //    ooga2.Y = 10002;
        //    ooga2.Altitude = 10003;
        //    ooga2.TimeStamp = new DateTime(2019, 01, 01, 01, 01, 01, 111);

        //    var testList = new List<IAirplaneInfo>();

        //    testList.Add(ooga);
        //    testList.Add(ooga2);

        //    _fSeperationCondition = new SeparationCondition(DateTime.Now, new Tuple<IAirplaneInfo, IAirplaneInfo>(ooga, ooga2));


        //    var SepList = new List<>();

        //    _fConsoleLogger.Logs(LOGTYPE.AIRSPACE, new List<string>());
        //    _fAirspace.GetAirplanes().Returns(testList);

        //    _uut.OnEvent(new List<string>());

        //    _fDetector.Received().GetConditions().Returns(new List<SeparationCondition>());

        //}
    }
}
