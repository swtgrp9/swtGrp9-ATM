using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using atmframework_swtgrp9;
using atmframework_swtgrp9.Interfaces;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;


namespace ATM.Test.Unit
{
   
    class AirplaneGenerator_Test
    {
        private AirplaneGenerator _uut;
        private string _fakeData1;
        private string _fakeData2;
        private AirplaneInfo _fakeTestPlane1;
        private AirplaneInfo _fakeTestPlane2;

        

        [SetUp]
        public void TestSetUp()
        {
            _fakeTestPlane1 = new AirplaneInfo();
            _fakeTestPlane2 = new AirplaneInfo();
            _fakeData1 = "SAS123;95000;31289;6500;20191101172101543";
            _fakeData2 = "SAS123;94846;31169;6500;20191101172102226";
        }

        //Test for om der kan genereres data for et fly
        [Test]
        public void GenerateAirplaneTransponderData_ReturnsPlane()
        {
            //Arrange
            _uut = new AirplaneGenerator();
            _fakeTestPlane1.Tag = "SAS123";
            _fakeTestPlane1.X = 95000;
            _fakeTestPlane1.Y = 31289;
            _fakeTestPlane1.Altitude = 6500;
            _fakeTestPlane1.TimeStamp = DateTime.ParseExact("20191101172101543", "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);

            //Act
            var airplane = _uut.Generate(_fakeData1);

            //Assert
            Assert.That(airplane.ToString(), Is.EqualTo(_fakeTestPlane1.ToString()));
        }

        //Test for at fly data kan opdateres for det i forvejen registrerede fly. 
        [Test]
        public void GenerateAirplaneThatAlreadyExists_UpdateInList()
        {
            //Arrange
            _uut = new AirplaneGenerator();
           
            _fakeTestPlane1.Tag = "SAS123";
            _fakeTestPlane1.X = 95000;
            _fakeTestPlane1.Y = 31289;
            _fakeTestPlane1.Altitude = 6500;
            _fakeTestPlane1.TimeStamp = DateTime.ParseExact("20191101172101543", "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);

            
            _fakeTestPlane2.Tag = "SAS123";
            _fakeTestPlane2.X = 94846;
            _fakeTestPlane2.Y = 31169;
            _fakeTestPlane2.Altitude = 6500;
            _fakeTestPlane2.TimeStamp = DateTime.ParseExact("20191101172102226", "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);
            
            _fakeTestPlane2.Course = 127.9;
            _fakeTestPlane2.Velocity = 285.8;
           
            

            //Act

            var testPlane2 = _uut.Generate(_fakeData2);

            //Assert
            Assert.That(testPlane2.ToString(), Is.EqualTo(_fakeTestPlane2.ToString()));
        }

        



        [TestCase("sas123", 0, 0, 0, 1, 0)] //0
        [TestCase("sas123", 0, 0, 0, 100, 0)] //0
        [TestCase("sas123", 0, -1, 0, 100, 0.5)] //0.5
        [TestCase("sas123", 0, -100, 0, 100, 45)] //45
        [TestCase("sas123", 0, -100, 0, 1, 89.5)] //89.5
        [TestCase("sas123", 0, 0, 0, 0, 90)] //90
        [TestCase("sas123", 0, -100, 0, -1, 90.5)] //90.5
        [TestCase("sas123", 0, -100, 0, -100, 135)] //135
        [TestCase("sas123", 0, -1, 0, -100, 179.5)] //179.5
        [TestCase("sas123", 0, 0, 0, -1, 180)] //180
        [TestCase("sas123", 0, 1, 0, -100, 180.5)] //180.5
        [TestCase("sas123", 0, 100, 0, -100, 225)] //225
        [TestCase("sas123", 0, 100, 0, -1, 269.5)] //269.5
        [TestCase("sas123", 0, 100, 0, 0, 270)] //270
        [TestCase("sas123", 0, 100, 0, 1, 270.5)] //270.5
        [TestCase("sas123", 0, 1, 0, 1, 315)] //315
        [TestCase("sas123", 0, 1, 0, 100, 359.5)] //359.5 grader
        public void Calculate_Course(string Tag, int X1, int X2, int Y1, int Y2, double result)
        {
            _uut = new AirplaneGenerator();

            _fakeTestPlane1.Tag = Tag;
            _fakeTestPlane1.X = X1;
            _fakeTestPlane1.Y = Y1;
            _fakeTestPlane1.Altitude = 0;

            _fakeTestPlane2.Tag = Tag;
            _fakeTestPlane2.X = X2;
            _fakeTestPlane2.Y = Y2;
            _fakeTestPlane2.Altitude = 0;

            

            double airplanecourse;
            airplanecourse = _uut.CalcCourse(_fakeTestPlane1, _fakeTestPlane2);


            Assert.That(airplanecourse, Is.EqualTo(result).Within(1.0));
        }

        [TestCase(0, 1, 0, 0, 0, 1, 1)]
        [TestCase(0, 0, 0, 0, 0, 1, 0)]
        [TestCase(-1, -2, -1, -2, 0, 1, 1.4142135623730952)]
        public void CalculateVelocity(int x1, int x2, int y1, int y2, int sec1, int sec2, double result)
        {
            _uut = new AirplaneGenerator();


            _fakeTestPlane1.Tag = "Test123";
            _fakeTestPlane1.X = x1;
            _fakeTestPlane1.Y = y1;
            _fakeTestPlane1.Altitude = 0;
            _fakeTestPlane1.Course = 0;
            //_fakeTestPlane1.Velocity = 10;
            _fakeTestPlane1.TimeStamp = new DateTime(2019, 10, 31, 13, 45, sec1);

            _fakeTestPlane2.Tag = "Test123";
            _fakeTestPlane2.X = x2;
            _fakeTestPlane2.Y = y2;
            _fakeTestPlane2.Altitude = 0;
            _fakeTestPlane1.Course = 0;
            //_fakeTestPlane1.Velocity = 10;
            _fakeTestPlane2.TimeStamp = new DateTime(2019, 10, 31, 13, 45, sec2);

            var airplaneSpeed = _uut.CalcVelocity(_fakeTestPlane1, _fakeTestPlane2);



            Assert.That(airplaneSpeed, Is.EqualTo(result));
        }
    }


}

