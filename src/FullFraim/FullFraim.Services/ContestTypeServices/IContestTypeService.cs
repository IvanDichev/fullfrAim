using FullFraim.Models.Dto_s.ContestType;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullFraim.Services.ContestTypeServices
{
    public interface IContestTypeService
    {
        Task<ICollection<OutputContestTypeModel>> GetAll();
        Task<OutputContestTypeModel> GetById(int id);
        Task<OutputContestTypeModel> Create(InputContestTypeModel model);
        Task<OutputContestTypeModel> Update(int id, InputContestTypeModel model);
        Task Delete(int id);
    }
}