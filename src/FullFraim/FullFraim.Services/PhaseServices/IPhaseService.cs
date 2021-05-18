using FullFraim.Models.Dto_s.Phases;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullFraim.Services.PhaseServices
{
    public interface IPhaseService
    {
        Task<ICollection<OutputPhaseModel>> GetAll();
        Task<OutputPhaseModel> GetById(int id);
        Task<OutputPhaseModel> Create(InputPhaseModel model);
        Task<OutputPhaseModel> Update(int id, InputPhaseModel model);
        Task Delete(int id);
    }
}