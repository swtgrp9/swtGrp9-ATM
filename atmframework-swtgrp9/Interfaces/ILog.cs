using System;
using System.Collections.Generic;
using System.Text;

namespace atmframework_swtgrp9.Interfaces
{
    public enum LOGTYPE
    {
        AIRSPACE,
        COLLISIONS,
        CLEAR
    }


    public interface ILog
    {
        void Logs(LOGTYPE type, List<string> logMessages);
    }
}
