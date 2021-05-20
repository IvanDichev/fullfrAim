using FullFraim.Data;
using FullFraim.Models.Dto_s.Photos;
using FullFraim.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utilities.Mapper;

namespace FullFraim.Services.PhotoServices
{
    public class PhotoService : IPhotoService
    {
        private readonly FullFraimDbContext context;

        public PhotoService(FullFraimDbContext context)
        {
            this.context = context;
        }
        public async Task<PhotoModel> CreateAsync(PhotoModel model)
        {
            if (model == null)
            {
                throw new NullModelException();
            }

            await this.context.Photos
                .AddAsync(model.MapToRaw());

            await this.context
                .SaveChangesAsync();

            return model;
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new InvalidIdException();
            }

            var modelToRemove = await this.context.Photos
                .FirstOrDefaultAsync(p => p.Id == id);

            modelToRemove.DeletedOn = DateTime.UtcNow;
            modelToRemove.IsDeleted = true;

            await this.context.SaveChangesAsync();
        }

        public async Task<ICollection<PhotoModel>> GetAllAsync()
        {
            var result = await this.context.Photos
                .MapToDto()
                .ToListAsync();

            return result;
        }

        public async Task<PhotoModel> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new InvalidIdException();
            }

            var result = await this.context.Photos
                .MapToDto()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (result == null)
            {
                throw new DbModelNotFoundException();
            }

            return result;
        }

        public async Task<PhotoModel> UpdateAsync(int id, PhotoModel model)
        {
            if (model == null)
            {
                throw new NullModelException();
            }

            var dbModelToUpdate = await this.context.Photos
                .FirstOrDefaultAsync(p => p.Id == id);

            if (dbModelToUpdate == null)
            {
                throw new DbModelNotFoundException();
            }

            dbModelToUpdate.Name = model.Name ?? dbModelToUpdate.Name;
            dbModelToUpdate.Description = model.Description ?? dbModelToUpdate.Description;
            dbModelToUpdate.Url = model.Url ?? dbModelToUpdate.Url;
            dbModelToUpdate.ModifiedOn = DateTime.UtcNow;

            await this.context.SaveChangesAsync();

            return model;
        }
    }
}
