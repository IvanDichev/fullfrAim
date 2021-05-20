using System;

namespace FullFraim.Services.Exceptions
{
    public class DbModelNotFoundException : ArgumentNullException
    {
        public DbModelNotFoundException()
        { }

        public DbModelNotFoundException(string message)
            : base(message)
        { }
    }
}
