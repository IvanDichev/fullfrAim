using FullFraim.Models.Dto_s.Contests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullFraim.Services.ContestServices
{
    public interface IContestService
    {
        Task<ICollection<ContestModel>> GetAll();
        Task<ContestModel> GetById(int id);
        Task<ContestModel> Create(ContestModel model);
        Task<ContestModel> Update(int id, ContestModel model);
        Task Delete(int id);
    }
}