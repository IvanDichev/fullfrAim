using System.Collections.Generic;

namespace FullFraim.Models
{
    public class PaginationPartialModel
    {
        public string Url { get; set; }
        public int TotalPages { get; set; }
        public string Query { get; set; }
    }
}
