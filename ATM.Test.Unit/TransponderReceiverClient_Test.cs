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

    }
}
