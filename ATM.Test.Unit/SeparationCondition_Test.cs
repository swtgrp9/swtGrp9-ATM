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

        [Test]
        public void IsLoggedTest_True()
        {
            _testSeparationCondition.IsLogged = true;
            Assert.That(_testSeparationCondition.IsLogged, Is.EqualTo(true));
        }

        [Test]
        public void IsLoggedTest_False()
        {
            _testSeparationCondition.IsLogged = false;
            Assert.That(_testSeparationCondition.IsLogged, Is.EqualTo(false));
        }

        [Test]
        public void IsLoggedTest_OppositeBool()
        {
            _testSeparationCondition.IsLogged = true;
            Assert.That(_testSeparationCondition.IsLogged, Is.Not.EqualTo(false));
        }


        [Test]
        public void TimeTest()
        {
            var uut = new DateTime(2019);
            Assert.That(_testSeparationCondition.Time, Is.EqualTo(uut));
        }


        [Test]
        public void IsEqualTestFalse() //Tester om fly med forskellge tags i hver sin condition ikke er lig hinanden (altså false) 
        {
            IAirplaneInfo airplane1 = Substitute.For<IAirplaneInfo>();
            IAirplaneInfo airplane2 = Substitute.For<IAirplaneInfo>();

            airplane1.Tag.Returns("Found");
            _testAirplaneInfo1.Tag.Returns("Not found");

            SeparationCondition isEqualTestFalseCondition = new SeparationCondition(new DateTime(2019), new Tuple<IAirplaneInfo, IAirplaneInfo>(airplane1, airplane2));

            Assert.That((_testSeparationCondition.EqualCondition(isEqualTestFalseCondition)), Is.EqualTo(false));

        }
    }
}
