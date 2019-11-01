using System;
using System.Collections.Generic;
using System.Text;
using atmframework_swtgrp9.Interfaces;
using System.Globalization;

namespace atmframework_swtgrp9
{
    public class Decoder : IDecoder
    {
        public string AirplaneTag { get; private set; }

        public int Xcoordinates { get; private set; }

        public int Ycoordinates { get; private set; }

        public int Altitude { get; private set; }

        public DateTime Time { get; private set; }

        public Decoder(string Data)
        {
            var dataArray = Data.Split(';');
            if (dataArray.Length != 5 ) { throw new Exception(); }
            AirplaneTag = dataArray[0];
            Xcoordinates = int.Parse(dataArray[1]);
            Ycoordinates = int.Parse(dataArray[2]);
            Altitude = int.Parse(dataArray[3]);
            Time = DateTime.ParseExact(dataArray[4], "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);
        }

       
    }
}
