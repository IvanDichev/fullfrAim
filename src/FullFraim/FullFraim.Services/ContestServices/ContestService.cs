﻿using FullFraim.Data;
using FullFraim.Models.Dto_s.Contests;
using FullFraim.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utilities.Mapper;

namespace FullFraim.Services.ContestServices
{
    public class ContestService : IContestService
    {
        private readonly FullFraimDbContext context;

        public ContestService(FullFraimDbContext context)
        {
            this.context = context;
        }

        public async Task<ContestModel> CreateAsync(ContestModel model)
        {
            if (model == null)
            {
                throw new NullModelException();
            }

            await this.context.Contests.AddAsync(model.MapToRaw());

            await this.context.SaveChangesAsync();

            return model;
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new InvalidIdException();
            }

            var modelToRemove = await this.context.Contests
                .FirstOrDefaultAsync(CC => CC.Id == id);

            modelToRemove.DeletedOn = DateTime.UtcNow;
            modelToRemove.IsDeleted = true;

            await this.context.SaveChangesAsync();
        }

        public async Task<ICollection<ContestModel>> GetAllAsync()
        {
            var result = await this.context.Contests
                .MapToDto()
                .ToListAsync();

            return result;
        }

        public async Task<ContestModel> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new InvalidIdException();
            }

            var result = await this.context.Contests
                .MapToDto()
                .FirstOrDefaultAsync(CC => CC.Id == id);

            if (result == null)
            {
                throw new DbModelNotFoundException();
            }

            return result;
        }

        public async Task<ContestModel> UpdateAsync(int id, ContestModel model)
        {
            if (model == null)
            {
                throw new NullModelException();
            }

            var dbModelToUpdate = await this.context.Contests
                .FirstOrDefaultAsync(CC => CC.Id == id);

            if (dbModelToUpdate == null)
            {
                throw new DbModelNotFoundException();
            }

            dbModelToUpdate.Name = model.Name ?? dbModelToUpdate.Name;
            dbModelToUpdate.ModifiedOn = DateTime.UtcNow;

            await this.context.SaveChangesAsync();

            return model;
        }
    }
}
