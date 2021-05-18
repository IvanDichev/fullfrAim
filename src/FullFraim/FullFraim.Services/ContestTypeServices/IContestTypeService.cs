using FullFraim.Models.Dto_s.ContestTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullFraim.Services.ContestTypeServices
{
    public interface IContestTypeService
    {
        Task<ICollection<ContestTypeModel>> GetAll();
        Task<ContestTypeModel> GetById(int id);
        Task<ContestTypeModel> Create(ContestTypeModel model);
        Task<ContestTypeModel> Update(int id, ContestTypeModel model);
        Task Delete(int id);
    }
}