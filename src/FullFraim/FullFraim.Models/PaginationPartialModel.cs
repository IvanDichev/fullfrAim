using System.Collections.Generic;

namespace FullFraim.Models
{
    public class PaginationPartialModel
    {
        public string Action { get; set; }
        public string Controller { get; set; }
        public int TotalPages { get; set; }
    }
}
