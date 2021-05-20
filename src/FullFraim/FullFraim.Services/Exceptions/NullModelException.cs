using System;

namespace FullFraim.Services.Exceptions
{
    public class NullModelException : ArgumentNullException
    {
        public NullModelException()
        { }

        public NullModelException(string message)
            :base(message)
        { }
    }
}
