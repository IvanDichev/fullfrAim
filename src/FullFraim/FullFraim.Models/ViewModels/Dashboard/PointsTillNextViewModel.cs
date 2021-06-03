using FullFraim.Models.Dto_s.Pagination;

namespace FullFraim.Models.ViewModels.Dashboard
{
    public class PointsTillNextViewModel
    {
        public string FullUserName { get; set; }
        public string Points { get; set; }
        public PaginationFilter Filter { get; set; }
    }
}
