using System;
using System.Collections.Generic;
using System.Text;
using atmframework_swtgrp9.Interfaces;
using System.Globalization;

namespace atmframework_swtgrp9
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
            AirplaneTag = dataArray[0];
            Xcoordinates = int.Parse(dataArray[1]);
            Ycoordinates = int.Parse(dataArray[2]);
            Altitude = int.Parse(dataArray[3]);
            Time = DateTime.ParseExact(dataArray[4], "yyyymmddhhmmssfff", CultureInfo.InvariantCulture);
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
