using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using atmframework_swtgrp9;
using atmframework_swtgrp9.Interfaces;
using NSubstitute;
using NUnit.Framework;


namespace ATM.Test.Unit
{
    [TestFixture]
    public class AirplaneGenerator_Test
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

        [Test]
        public void CalculateCourseNotEqualTo90degrees()
        {
            _fakeTestPlane1.Tag = "SAS123";
            _fakeTestPlane1.X = 1000;
            _fakeTestPlane2.Y = 1000;

            _fakeTestPlane2.Tag = "SAS123";
            _fakeTestPlane2.X = 2000;
            _fakeTestPlane2.Y = 2000;

            _uut.CalcCourse(_fakeTestPlane1, _fakeTestPlane2);
            Assert.That(_fakeTestPlane2.Course, Is.Not.EqualTo(90));
        }

        [TestCase(0, 0, 0, 0, 0)]
        [TestCase(0, 0, 0, 1, 0)]
        [TestCase(0, 1, 0, 100, 0.5)] //Første kvadrant, tæt ved 360/0 grader
        [TestCase(0, 100, 0, 1, 89.5)] //Første kvadrant, tæt ved 90 grader
        [TestCase(0, 1, 0, 1, 90)] //90 grader
        [TestCase(0, 100, 0, -1, 90.5)] //Anden kvadrant, tæt ved 90 grader
        [TestCase(0, 1, 0, -100, 179.5)] //Anden kvadrant, tæt ved 180 grader
        [TestCase(0, 0, 0, -1, 180)] //180 grader
        [TestCase(0, -1, 0, -100, 180.5)] //Tredje kvadrant, tæt ved 180 grader
        [TestCase(0, -100, 0, -1, 269.5)] //Tredje kvadrant, tæt ved 270 grader
        [TestCase(0, -1, 0, 0, 270)] //270
        [TestCase(0, -100, 0, 1, 270.5)] //Fjerde kvadrant, tæt ved 270 grader
        [TestCase(0, -1, 0, 100, 359.5)] //Fjerde kvadrant, tæt ved 360/0 grader.

        public void Calculate_Course(string Tag, int X1, int X2, int Y1, int Y2, double result)
        {
            _fakeTestPlane1.SetAirplaneInfo(Tag, X1, Y1, 0, new DateTime());
            _fakeTestPlane2.SetAirplaneInfo(Tag, X2, Y2, 0, new DateTime());

            List<AirplaneInfo> list1 = new List<AirplaneInfo>();
            List<AirplaneInfo> list2 = new List<AirplaneInfo>();

            list1.Add(_fakeTestPlane1);
            list2.Add(_fakeTestPlane2);



            AirplaneInfo a1course = new AirplaneInfo();

            a1course = AirplaneGenerator.CalcCourse(a1, a2);

            Assert.That(a1course.Course, Is.EqualTo(result).Within(0.4));
        }
    }
}
