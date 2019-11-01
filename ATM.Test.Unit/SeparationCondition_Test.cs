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
    class SeparationConditionTest
    {
        private SeparationCondition _testSeparationCondition;
        private IAirplaneInfo _testAirplaneInfo1;
        private IAirplaneInfo _testAirplaneInfo2;

        [SetUp]
        public void Setup()
        {
            //Create mocks
            _testAirplaneInfo1 = Substitute.For<IAirplaneInfo>();
            _testAirplaneInfo2 = Substitute.For<IAirplaneInfo>();

            //Tuple containing the two mocks
            Tuple<IAirplaneInfo, IAirplaneInfo> testTuple = new Tuple<IAirplaneInfo, IAirplaneInfo>(_testAirplaneInfo1, _testAirplaneInfo2);

            _testSeparationCondition = new SeparationCondition(new DateTime(2019), testTuple);
        }

        [Test]
        public void PairAirplanesTest()
        {
            Tuple<IAirplaneInfo, IAirplaneInfo> uut = new Tuple<IAirplaneInfo, IAirplaneInfo>(_testAirplaneInfo1, _testAirplaneInfo2);

            Assert.That((_testSeparationCondition.PairAirplanes) , Is.EqualTo(uut));
        }
    }
}
