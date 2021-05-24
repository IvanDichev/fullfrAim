namespace FullFraim.Models.Dto_s.Pagination
{
    public class PaginationFilter
    {
        private const int MaxPageSize = 50;
        private const int MinPageNumber = 1;

        private int pageNumber;
        private int pageSize;

        public int PageNumber
        {
            get => pageNumber;
            set => pageNumber = value < MinPageNumber ? MinPageNumber : value;
        }

        public int PageSize
        {
            get => pageSize;
            set => pageSize = value > MaxPageSize ? MaxPageSize : value;
        }

        public PaginationFilter()
        {
            this.pageNumber = 1;
            this.pageSize = 10;
        }

        public PaginationFilter(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
        }
    }
}
