﻿using System;
using System.Collections.Generic;
using System.Text;
using atmframework_swtgrp9.Interfaces;

namespace atmframework_swtgrp9.Interfaces
{
    public interface IAirplaneGenerator
    {
        IAirplaneInfo Generate(string planeData);

        
    }
}
