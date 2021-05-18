using FullFraim.Models.Dto_s.Contests;
using System.Threading.Tasks;

namespace FullFraim.Services.ContestServices
{
    public interface IContestService
    {
        public Task<InputContestModel> Create(InputContestModel model);
    }
}