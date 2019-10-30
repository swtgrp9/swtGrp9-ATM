using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Core.Interfaces
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
