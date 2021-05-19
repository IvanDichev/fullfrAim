using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FullFraim.Services.ContestCategoryService
{
    public interface IContestCategoryService
    {
        IQueryable GetAll();
        IQueryable GetById(int id);
        IQueryable Create();
    }
}
