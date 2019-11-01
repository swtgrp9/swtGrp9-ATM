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

            uut.Add(testPlane1);
            List<IAirplaneInfo> listOfAirplanes = uut.GetAirplanes();

            Assert.That(listOfAirplanes[0].Tag, Is.EqualTo("Test1"));
        }
        
        [Test]
        public void AddAirplaneToAirspaceWithOnePlane_AddedCorrectPlane()
        {
            IAirplaneInfo testPlane1 = Substitute.For<IAirplaneInfo>();
            testPlane1.Tag.Returns("Testplane1");
            uut.Add(testPlane1);

            IAirplaneInfo testPlane2 = Substitute.For<IAirplaneInfo>();
            testPlane2.Tag.Returns("Testplane2");
            uut.Add(testPlane2);

            List<IAirplaneInfo> listOfAirplanes = uut.GetAirplanes();



            Assert.That(listOfAirplanes[1].Tag, Is.EqualTo("Testplane2"));
        }

        [Test]
        public void AddAirplaneAlreadynAirspace_OneAirplaneAlreadyInAirspace()
        {
            IAirplaneInfo testPlane1 = Substitute.For<IAirplaneInfo>();
            testPlane1.Tag.Returns("Testplane1");
            uut.Add(testPlane1);

            IAirplaneInfo testPlane2 = Substitute.For<IAirplaneInfo>();
            testPlane2.Tag.Returns("Testplane2");
            uut.Add(testPlane2);

            

        }

    }
}
