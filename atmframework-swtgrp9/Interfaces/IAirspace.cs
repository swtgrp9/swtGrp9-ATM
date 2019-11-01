using System;
using System.Collections.Generic;
using System.Text;

namespace atmframework_swtgrp9.Interfaces
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

        List<T> GetAirplanes();

    }
}
