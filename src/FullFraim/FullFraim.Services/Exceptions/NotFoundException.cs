using System;

namespace FullFraim.Services.Exceptions
{
    public class NotFoundException : ArgumentNullException
    {
        public NotFoundException()
        { }

        public NotFoundException(string message)
            : base(message)
        { }
    }
}
