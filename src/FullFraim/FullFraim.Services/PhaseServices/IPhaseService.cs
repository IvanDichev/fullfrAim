using FullFraim.Models.Dto_s.Phases;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullFraim.Services.PhaseServices
{
    public interface IPhaseService
    {
        Task<ICollection<PhaseModel>> GetAllAsync();
        Task<PhaseModel> GetByIdAsync(int id);
        Task<PhaseModel> CreateAsync(PhaseModel model);
        Task<PhaseModel> UpdateAsync(int id, PhaseModel model);
        Task DeleteAsync(int id);
    }
}