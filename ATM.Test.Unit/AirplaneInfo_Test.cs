using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using atmframework_swtgrp9;
using NSubstitute;
using NUnit.Framework;

namespace ATM.Test.Unit
{
    [TestFixture]
    class AirplaneInfo_Test
    {
        internal class ClassTestData
        {
            //Arrange 

            private static AirplaneInfo testAirplane = new AirplaneInfo();
            private static int testInteger = 100;
            private static double testDouble = 100.0;
            private static string testString = "testString";
            private static DateTime testTime = new DateTime(2019, 10, 31);



            //Act
            public static IEnumerable TestProperties
            {
                //Inserting data for the AirplaneInfo variables
                get
                {
                    //Act
                    yield return new TestCaseData(new AirplaneInfo().Tag = testString, "testString").SetName("Plane Tag");

                    yield return new TestCaseData(new AirplaneInfo().Altitude = testInteger, 100).SetName("Plane Altitude");

                    yield return new TestCaseData(new AirplaneInfo().X = testInteger, 100).SetName("Plane X-coordinate");

                    yield return new TestCaseData(new AirplaneInfo().Y = testInteger, 100).SetName("Plane Y-coordinate");

                    yield return new TestCaseData(new AirplaneInfo().Course = testDouble, 100.0).SetName("Plane Course");

                    yield return new TestCaseData(new AirplaneInfo().Velocity = testDouble, 100.0).SetName("Plane Velocity");

                    yield return new TestCaseData(new AirplaneInfo().TimeStamp = testTime, new DateTime(2019, 10, 31)).SetName("Plane Time");


                }
            }
        }

        //Assert

        //Testing 
        [TestCaseSource(typeof(ClassTestData), "TestProperties")]

        public void AirplaneProperties<T>(T property, T testResult)
        {
            Assert.That(property, Is.EqualTo(testResult));
        }
    }
}
