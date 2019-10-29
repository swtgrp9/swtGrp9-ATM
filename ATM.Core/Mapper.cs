using System;
using System.Collections.Generic;
using System.Text;
using ATM.Core.Interfaces;

namespace ATM.Core
{
    public class Mapper : IMapper
    {
        public string AirplaneTag { get; private set; }

        public int Xcoordinates { get; private set; }

        public int Ycoordinates { get; private set; }

        public int Altitude { get; private set; }

        public DateTime Time { get; private set; }

        public Mapper(string Data)
        {
            var dataArray = Data.Split(';');
            if (dataArray.Length != 5 ) { throw new Exception(); }
            
        }

        //public void SetTag(string tag)
        //{

        //}

        //public string GetTag()
        //{
        //    return string;
        //}

        //public void SetX(int x)
        //{

        //}

        //public int GetX()
        //{
        //    return 1;
        //}

        //public void SetY(int y)
        //{
            
        //}

        //public int GetY()
        //{
        //    return 1;
        //}

        //public void SetAlt(int alt)
        //{
            
        //}

        //public int GetAlt()
        //{
        //    return 1;
        //}

        //public void SetTime(DateTime time)
        //{

        //}

        //public DateTime GetTime()
        //{
        //    return;
        //}
    }
}
