using FullFraim.Models.Dto_s.AccountAPI;
using System.Threading.Tasks;

namespace FullFraim.Services.API_JwtServices
{
    public interface IJwtServices
    {
        Task<OutputLoginModel_API> Login(InputLoginModel_API model);
        Task<bool> Register(RegisterInputModel_API model);
    }
}
