using System;
using System.Collections.Generic;
using System.Text;

namespace FullFraim.Services.API_JwtServices
{
    public interface IJwtServices
    {
        string Login(string username, ICollection<string> roles);
    }
}
