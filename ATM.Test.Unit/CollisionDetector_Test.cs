using System;
using System.Collections.Generic;
using System.Collections;
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
            _log = Substitute.For<ILog>();

            _uut = new CollisionDetector(_log);

            _testAirspace = new List<IAirplaneInfo>();
            _testAirplaneInfo1 = Substitute.For<IAirplaneInfo>();
            _testAirplaneInfo2 = Substitute.For<IAirplaneInfo>();

            _testAirspace.Add(_testAirplaneInfo1);
            _testAirspace.Add(_testAirplaneInfo2);


        }
    }
}
