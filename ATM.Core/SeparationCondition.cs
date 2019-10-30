using System;
using System.Collections.Generic;
using System.Text;
using ATM.Core.Interfaces;

namespace ATM.Core
{
    public class SeparationCondition : ITime
    {
        private DateTime _time;
        private Tuple<IAirplaneinfo, IAirplaneinfo> _pairAirplanes;
        private bool _isLogged;

        public Datetime Time
        {
            get => _time;
        }

        public Tuple<IAirplaneinfo, IAirplaneinfo> PairAirplanes
        {
            get => _pairAirplanes;
        }

        public bool IsLogged
        {
            get => _isLogged;
            set => _isLogged = value;
        }

        public SeparationCondition(DateTime time, Tuple<IAirplaneinfo, IAirplaneinfo> pairAirplanes)
        {
            _time = time;
            _pairAirplanes = pairAirplanes;
        }
    }
}
