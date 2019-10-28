using System;
using System.Collections.Generic;
using System.Text;
using ATM.Core.Interfaces;

namespace ATM.Core
{
    public class Airspace : IAirspace<IAirplaneInfo>
    {
        private readonly Dictionary<string, IAirplaneInfo> _airplanesInAirspace;

        private const int X1 = 10000;
        private const int X2 = 90000;
        private const int Y1 = 10000;
        private const int Y2 = 90000;
        private const int Alt1 = 500;
        private const int Alt2 = 20000;

        public Airspace()
        {
            _airplanesInAirspace = new Dictionary<string, IAirplaneInfo>();
        }

        public int GetX1()
        {
            return X1;
        }
        public int GetX2()
        {
            return X2;
        }

        public int GetY1()
        {
            return Y1;
        }
        public int GetY2()
        {
            return Y2;
        }
        public int GetAlt1()
        {
            return Alt1;
        }

        public int GetAlt2()
        {
            return Alt2;
        }

        public void Add(IAirplaneInfo a1)
        {
            if(_airplanesInAirspace.ContainsKey(a1.Tag)
            {
                _airplanesInAirspace[a1.Tag] = a1;
            }
            else
            {
                _airplanesInAirspace.Add(a1.Tag, a1);
            }
        }

        public void Remove(IAirplaneInfo a1)
        {
            if (_airplanesInAirspace.ContainsKey(a1.Tag)
            {
                _airplanesInAirspace.Remove(a1.Tag);
            }
            
        }

        public List<IAirplaneInfo> GetAirplanes()
        {
            return new List<IAirplaneInfo>(_airplanesInAirspace.Values);
        }
    }
}
