using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using atmframework_swtgrp9;
using atmframework_swtgrp9.Interfaces;
using NUnit.Framework;
using NSubstitute;


namespace ATM.Test.Unit
{
    [TestFixture]
    class Decoder_Test
    {
        internal class TestClass
        {
            //Arrange
            private static string _exampleTestString = "FLY;10;20;30;20191101172102226";

            //Act
            public static IEnumerable CorrectCases
            {

                get
                {
                    //Act

                    yield return new TestCaseData(new Decoder(_exampleTestString).AirplaneTag, "FLY").SetName("Tag");

                    yield return new TestCaseData(new Decoder(_exampleTestString).Xcoordinates, 10).SetName("X position");

                    yield return new TestCaseData(new Decoder(_exampleTestString).Ycoordinates, 20).SetName("Y position");

                    yield return new TestCaseData(new Decoder(_exampleTestString).Altitude, 30).SetName("Altitude");

                    yield return new TestCaseData(new Decoder(_exampleTestString).Time, new DateTime(2019, 11, 01, 17, 21,02,226)).SetName("TimeStamp");

                }
            }
        }

        //Assert
        //Test for om den kan decode en given besked

        [TestCaseSource(typeof(TestClass), "CorrectCases")]
        public void DecodingCorrectly<T>(T property, T decodeResult)
        {
            Assert.That(property, Is.EqualTo(decodeResult));
        }

        //Test for forkert decoding -> smider exception
        [Test]
        public void DecodingWrong()
        {
            //Arrange
            string exampleTestString2 = "123;number;number;number;2019-11-01-22-45-42-400";

            //Act & Assert
            Assert.That(() => new Decoder(exampleTestString2), Throws.TypeOf<FormatException>());
        }
    }
}