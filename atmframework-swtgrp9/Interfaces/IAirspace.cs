using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Core.Interfaces
{
    public interface IAirspace<T>
    {
        int GetX1();
        int GetX2();

        int GetY1();
        int GetY2();
        int GetAlt1();

        int GetAlt2();

        void Add(T construct);

        void Remove(T construct);

        System.Collections.Generic.List<T> GetAirplanes();

    }
}
