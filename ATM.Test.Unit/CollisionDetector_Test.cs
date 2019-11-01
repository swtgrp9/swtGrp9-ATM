using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using atmframework_swtgrp9;
using atmframework_swtgrp9.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace ATM.Test.Unit
{
    [TestFixture]
    class CollisionDetectorTest
    {
        private List<IAirplaneInfo> _testAirspace;
        private IAirplaneInfo _testAirplaneInfo1;
        private IAirplaneInfo _testAirplaneInfo2;

        private ILog _log;

        private CollisionDetector _uut;

        [SetUp]
        public void Setup()
        {

            _log = Substitute.For<FileLogger, ILog>("test");

            _uut = new CollisionDetector(_log);

            _testAirspace = new List<IAirplaneInfo>();
            _testAirplaneInfo1 = Substitute.For<IAirplaneInfo>();
            _testAirplaneInfo2 = Substitute.For<IAirplaneInfo>();

            _testAirspace.Add(_testAirplaneInfo1);
            _testAirspace.Add(_testAirplaneInfo2);

        }

        [Test]
        public void RegisterAirplanesCollidingXY()
        {
            _testAirplaneInfo1.X.Returns(35000);
            _testAirplaneInfo1.Y.Returns(35000);
            _testAirplaneInfo1.Altitude.Returns(600);

            _testAirplaneInfo2.X.Returns(35000);
            _testAirplaneInfo2.Y.Returns(35000);
            _testAirplaneInfo2.Altitude.Returns(1100);

            _uut.Register(_testAirspace);

            Assert.That(_uut.GetConditions().Count, Is.EqualTo(1));
        }

        //[Test]
        //public void RegisterAirplanesNotColliding()
        //{
        //    _testAirplaneInfo1.X.Returns(35000);
        //    _testAirplaneInfo1.Y.Returns(50000);
        //    _testAirplaneInfo1.Altitude.Returns(600);

        //    _testAirplaneInfo2.X.Returns(50000);
        //    _testAirplaneInfo2.Y.Returns(80000);
        //    _testAirplaneInfo2.Altitude.Returns(1100);

        //    _uut.Register(_testAirspace);

        //    Assert.That(_uut.GetConditions().Count, Is.EqualTo(0));
        //}

        [Test] //Test for om der Log funktionen bliver kaldt når der er collision
        public void CheckIfLogCalled()
        {
            _testAirplaneInfo1.X.Returns(35000);
            _testAirplaneInfo1.Y.Returns(35000);
            _testAirplaneInfo1.Altitude.Returns(600);

            _testAirplaneInfo2.X.Returns(35000);
            _testAirplaneInfo2.Y.Returns(35000);
            _testAirplaneInfo2.Altitude.Returns(1100);

            _uut.Register(_testAirspace);

            _log.Received().Logs(LOGTYPE.COLLISIONS,  Arg.Any<List<string>>());
        }
    }
}
