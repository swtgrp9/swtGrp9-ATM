using System;
using System.Collections.Generic;
using System.Text;
using TransponderReceiver;
using ATM.Core.Interfaces;

namespace ATM.Core
{
    class AirTrafficMonitor
    {
        private RegisterCondition _condition;
        private IAirspace<IAirplaneInfo> _airspace;
        private IAirplaneGenerator _generator;
        private ILog _consoleLog;
        private ILog _fileLog;

        public AirTrafficMonitor
        (
            FileLogger fileLog,
            ConsoleLogger consoleLog,
            RegisterCondition register,
            IAirspace<IAirplaneInfo> airspace,
            IAirplaneGenerator generator
        )
        {
            _fileLog = fileLog;
            _consoleLog = consoleLog;
            _condition = register;
            _airspace = airspace;
            _generator = generator;
        }

        public  void OnEvent

    }
}
