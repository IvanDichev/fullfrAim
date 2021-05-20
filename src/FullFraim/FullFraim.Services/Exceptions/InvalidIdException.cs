﻿using System;

namespace FullFraim.Services.Exceptions
{
    public class InvalidIdException : ArgumentException
    {
        public InvalidIdException()
        { }

        public InvalidIdException(string message)
            :base(message)
        { }
    }
}
