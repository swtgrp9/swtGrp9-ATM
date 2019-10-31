using System;
using System.Collections.Generic;
using System.Text;

namespace atmframework_swtgrp9.Interfaces
{
    public interface ICollisionDetector
    {
        void Register(List<IAirplaneInfo> compareList);
    }
}
