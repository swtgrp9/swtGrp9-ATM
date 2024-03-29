﻿using System;
using System.Collections.Generic;
using System.Text;
using atmframework_swtgrp9.Interfaces;

namespace atmframework_swtgrp9
{
    public class SeparationCondition : ITime
    {
        private DateTime _time;
        private Tuple<IAirplaneInfo, IAirplaneInfo> _pairAirplanes;
        private bool _isLogged;

        public DateTime Time
        {
            get => _time;
        }

        public Tuple<IAirplaneInfo, IAirplaneInfo> PairAirplanes
        {
            get => _pairAirplanes;
        }

        public bool IsLogged
        {
            get => _isLogged;
            set => _isLogged = value;
        }

        public SeparationCondition(DateTime time, Tuple<IAirplaneInfo, IAirplaneInfo> pairAirplanes)
        {
            _time = time;
            _pairAirplanes = pairAirplanes;
        }

        //Bruges til at tjekke om en condition tidligere er forefundet.
        public bool EqualCondition(SeparationCondition otherCondition)
        {
            if (string.Equals(this.PairAirplanes.Item1.Tag, otherCondition.PairAirplanes.Item1.Tag) && string.Equals(this.PairAirplanes.Item2.Tag, otherCondition.PairAirplanes.Item2.Tag))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
