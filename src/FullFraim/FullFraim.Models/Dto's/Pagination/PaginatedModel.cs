using System;
using System.Collections.Generic;

namespace FullFraim.Models.Dto_s.Pagination
{
    public class PaginatedModel<T> where T : class
    {
        public ICollection<T> Model { get; set; }

        public int RecordsPerPage { get; set; }

        public int TotalPages { get; set; }

        public object Where(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}
