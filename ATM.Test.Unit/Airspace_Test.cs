using System;
using System.Collections;
using System.Collections.Generic;
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
    class Airspace_Test
    {
        private Airspace uut;

        [SetUp]
        public void Setup()
        {
            uut = new Airspace();
        }

        [Test]
        public void AddAirplaneToEmptyAirspace_AddedCorrectPlane()
        {
            IAirplaneInfo testPlane1 = Substitute.For<IAirplaneInfo>();
            testPlane1.Tag.Returns("Test1");

            
        }
        
    }
}
