using FullFraim.Models.Dto_s.AccountAPI;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullFraim.Services.API_JwtServices
{
    public interface IJwtServices
    {
        Task<string> Login(string userName, string password);
        Task<bool> Register(RegisterInputModel model);
    }
}
