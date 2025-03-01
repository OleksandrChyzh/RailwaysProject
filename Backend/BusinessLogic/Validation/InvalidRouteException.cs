﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Validation
{
    public class InvalidRouteException : RailwaysException
    {
        public InvalidRouteException(string message)
            : base(message)
        {
        }
    }
}
