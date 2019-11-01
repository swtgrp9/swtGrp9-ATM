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
        private SeparationCondition testSeparationCondition;
        private IAirplaneInfo testAirplaneInfo1;
        private IAirplaneInfo testAirplaneInfo2;

        [SetUp]
        public void Setup()
        {
            //Create mocks
            testAirplaneInfo1 = Substitute.For<IAirplaneInfo>();
            testAirplaneInfo2 = Substitute.For<IAirplaneInfo>();

            //Tuple containing the two mocks
            Tuple<IAirplaneInfo, IAirplaneInfo> testTuple = new Tuple<IAirplaneInfo, IAirplaneInfo>(testAirplaneInfo1, testAirplaneInfo2);

            testSeparationCondition = new SeparationCondition(new DateTime(2019), testTuple);
        }

        [Test]
        public void 
    }
}
