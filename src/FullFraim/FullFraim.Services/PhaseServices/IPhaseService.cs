using FullFraim.Models.Dto_s.Phases;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullFraim.Services.PhaseServices
{
    public interface IPhaseService
    {
        Task<ICollection<PhaseModel>> GetAll();
        Task<PhaseModel> GetById(int id);
        Task<PhaseModel> Create(PhaseModel model);
        Task<PhaseModel> Update(int id, PhaseModel model);
        Task Delete(int id);
    }
}