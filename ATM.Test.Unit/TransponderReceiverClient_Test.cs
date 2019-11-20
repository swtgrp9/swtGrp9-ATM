using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using atmframework_swtgrp9;
using atmframework_swtgrp9.Interfaces;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;

namespace ATM.Test.Unit
{
    [TestFixture]
    class TransponderReceiverClient_Test
    {
        private ITransponderReceiver _fTransponderReceiver;
        private TransponderReceiverClient _uut;

        [SetUp]
        public void Setup()
        {
            _fTransponderReceiver = Substitute.For<ITransponderReceiver>();
        }

        [Test]
        public void DataReceivedTest() //Tester at TransponderReceiverClient opfører sig korrekt ved event fra TransponderReceiver.dll
        {
            var _fAction = Substitute.For<Action<List<string>>>();
            var _actionCalled = false;

            void _fOnAction(List<string> d)
            {
                _actionCalled = true;
            }

            _uut = new TransponderReceiverClient(_fOnAction, _fTransponderReceiver);

            List<string> dataList = new List<string>();
            dataList.Add("SAS123;10001;12000;11000;20191119183855890");

            _fTransponderReceiver.TransponderDataReady +=
                Raise.EventWith(this, new RawTransponderDataEventArgs(dataList));

            Assert.That(_actionCalled, Is.EqualTo(true));


        }

    }
}
