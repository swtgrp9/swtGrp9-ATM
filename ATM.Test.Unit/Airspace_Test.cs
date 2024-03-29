﻿using System;
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

        //Test for om der kan tilføjes fly i airspacet. 
        [Test]
        public void AddAirplaneToEmptyAirspace_AddedCorrectPlane()
        {
            IAirplaneInfo testPlane1 = Substitute.For<IAirplaneInfo>();
            testPlane1.Tag.Returns("Test1");

            uut.Add(testPlane1);
            List<IAirplaneInfo> listOfAirplanes = uut.GetAirplanes();

            Assert.That(listOfAirplanes[0].Tag, Is.EqualTo("Test1"));
        }
        
        //Test for om der kan tilføjes mere end et fly
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

        //Test for om der kan tilføjes fly i airspacet når det allerede findes i airspacet. 
        [Test]
        public void AddAirplaneAlreadyInAirspace_OneAirplaneAlreadyInAirspace()
        {
            IAirplaneInfo testPlane1 = Substitute.For<IAirplaneInfo>();
            testPlane1.Tag.Returns("Testplane");
            uut.Add(testPlane1);

            IAirplaneInfo testPlane2 = Substitute.For<IAirplaneInfo>();
            testPlane2.Tag.Returns("Testplane");
            uut.Add(testPlane2);

            List<IAirplaneInfo> listOfAirplanes = uut.GetAirplanes();


            Assert.That(() => listOfAirplanes[1].Tag, Throws.TypeOf<ArgumentOutOfRangeException>());

        }

        //Test for om der stadig kan findes tideligere tilføjet fly i listen af fly.
        [Test]
        public void AddAirplaneAlreadyInAirspace_PlaneStillExistInList()
        {
            IAirplaneInfo testPlane1 = Substitute.For<IAirplaneInfo>();
            testPlane1.Tag.Returns("Testplane");
            uut.Add(testPlane1);

            IAirplaneInfo testPlane2 = Substitute.For<IAirplaneInfo>();
            testPlane2.Tag.Returns("Testplane");
            uut.Add(testPlane2);

            List<IAirplaneInfo> listOfAirplanes = uut.GetAirplanes();

            Assert.That(listOfAirplanes[0].Tag, Is.EqualTo("Testplane"));
        }

        //Test for om der kan fjernes et fly fra Airspacet.
        [Test]
        public void RemoveAirplaneFromAirspace_OnePlaneInAirspace()
        {
            IAirplaneInfo testplane1 = Substitute.For<IAirplaneInfo>();
            testplane1.Tag.Returns("Testplane1");
            uut.Add(testplane1);

            uut.Remove(testplane1);

            List<IAirplaneInfo> listOfAirplanes = uut.GetAirplanes();

            Assert.That(() => listOfAirplanes[0].Tag, Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        //Test for om der kan returneres et tilføjet fly i Airspacet
        [Test]
        public void GetAirplanesFromAirspace_ReturnsListOfPlanes_AirplanesInAirspace()
        {
            IAirplaneInfo testplane1 = Substitute.For<IAirplaneInfo>();
            testplane1.Tag.Returns("Testplane1");
            uut.Add(testplane1);

            List<IAirplaneInfo> listOfAirplanes = uut.GetAirplanes();

            Assert.That(listOfAirplanes[0].Tag, Is.EqualTo("Testplane1"));
        }

        //Test for forsøg på at hente fly fra et tomt airspace
        [Test]
        public void GetAirplanesFromAirspace_EmptyAirspace()
        {

            List<IAirplaneInfo> listOfAirplanes = uut.GetAirplanes();
            
            Assert.That(() => listOfAirplanes[0].Tag, Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        //Test for maksimale grænse for X-aksen
        [Test]
        public void GetXMax_Returns90000()
        {
            int Xmax = uut.GetX2();

            Assert.That(Xmax, Is.EqualTo(90000));
        }

        //Test for minimale grænse for X-aksen
        [Test]
        public void GetXMin_Returns10000()
        {
            int Xmin = uut.GetX1();

            Assert.That(Xmin, Is.EqualTo(10000));

        }

        //Test for maksimale grænse for Y-aksen
        [Test]
        public void GetYMax_Returns90000()
        {
            int Ymax = uut.GetY2();

            Assert.That(Ymax, Is.EqualTo(90000));
        }

        //Test for minimale grænse for Y-aksen
        [Test]
        public void GetYMin_Returns10000()
        {
            int Ymin = uut.GetY1();

            Assert.That(Ymin, Is.EqualTo(10000));

        }

        //Test for maksimale grænse for altituden
        [Test]
        public void GetAltitudeMax_Returns20000()
        {
            int AltitudeMax = uut.GetAlt2();

            Assert.That(AltitudeMax, Is.EqualTo(20000));
        }

        //Test for minimale grænse for altituden
        [Test]
        public void GetAltitudeMin_Returns500()
        {
            int AltitudeMin = uut.GetAlt1();

            Assert.That(AltitudeMin, Is.EqualTo(500));
        }

    }
}
