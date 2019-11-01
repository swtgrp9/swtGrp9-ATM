using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using atmframework_swtgrp9;
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
            _fakeData1 = "SAS123;89855;43075;1100;20191101120513900";
            _fakeData2 = "SAS321;64059;93446;17800;20191101120515273";
        }

        [Test]
        public void GenerateAirplaneTransponderData_ReturnsPlane()
        {
            //Arrange
            _uut = new AirplaneGenerator();
            _fakeTestPlane1.Tag = "SAS123";
            _fakeTestPlane1.X = 89855;
            _fakeTestPlane1.Y = 43075;
            _fakeTestPlane1.Altitude = 1100;
            _fakeTestPlane1.TimeStamp = DateTime.ParseExact("20191101120513900", "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);

            
        }
    }
}
