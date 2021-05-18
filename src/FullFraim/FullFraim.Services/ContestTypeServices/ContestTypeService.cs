using FullFraim.Data;
using FullFraim.Models.Dto_s.ContestTypes;
using FullFraim.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utilities.Mapper;

namespace FullFraim.Services.ContestTypeServices
{
    public class ContestTypeService : IContestTypeService
    {
        private readonly FullFraimDbContext context;

        public ContestTypeService(FullFraimDbContext context)
        {
            this.context = context;
        }

        public async Task<ContestTypeModel> Create(ContestTypeModel model)
        {
            if (model == null)
            {
                throw new NullModelException();
            }

            var result = await this.context.ContestTypes
                .AddAsync(model.MapToRaw());

            await this.context
                .SaveChangesAsync();

            return result.Entity
                .MapToDto();
        }

        public async Task Delete(int id)
        {
            if (id <= 0)
            {
                throw new InvalidIdException();
            }

            var modelToRemove = await this.context.ContestTypes
                .FirstOrDefaultAsync(CC => CC.Id == id);

            modelToRemove.DeletedOn = DateTime.UtcNow;
            modelToRemove.IsDeleted = true;

            await this.context.SaveChangesAsync();
        }

        public async Task<ICollection<ContestTypeModel>> GetAll()
        {
            var DbResult = await this.context.ContestTypes.ToListAsync();

            var result = new List<ContestTypeModel>();

            foreach (var contestType in DbResult)
            {
                result.Add(contestType.MapToDto());
            }

            return result;
        }

        public async Task<ContestTypeModel> GetById(int id)
        {
            if (id <= 0)
            {
                throw new InvalidIdException();
            }

            var result = await this.context.ContestTypes
                .FirstOrDefaultAsync(CC => CC.Id == id);

            if (result == null)
            {
                throw new DbModelNotFoundException();
            }

            return result.MapToDto();
        }

        public async Task<ContestTypeModel> Update(int id, ContestTypeModel model)
        {
            if (model == null)
            {
                throw new NullModelException();
            }

            var dbModelToUpdate = await this.context.ContestTypes
                .FirstOrDefaultAsync(CC => CC.Id == id);

            if (dbModelToUpdate == null)
            {
                throw new DbModelNotFoundException();
            }

            dbModelToUpdate.Name = model.Name ?? dbModelToUpdate.Name;
            dbModelToUpdate.ModifiedOn = DateTime.UtcNow;

            return dbModelToUpdate.MapToDto();
        }
    }
}
