using FullFraim.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullFraim.Services.PhotoService
{
    public class PhotoService : IPhotoService
    {
        private readonly FullFraimDbContext context;

        public PhotoService(FullFraimDbContext context)
        {
            this.context = context;
        }
    }
}
