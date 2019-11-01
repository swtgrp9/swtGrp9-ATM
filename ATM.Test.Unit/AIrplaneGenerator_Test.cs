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
            var testPlane1 = _uut.Generate(_fakeData1);
            var testPlane2 = _uut.Generate(_fakeData2);

            //Assert
            Assert.That(testPlane2.ToString(), Is.EqualTo(_fakeTestPlane2.ToString()));
        }
    }
}
