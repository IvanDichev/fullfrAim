using FullFraim.Models.Dto_s.Reviews;
using System.Collections.Generic;

namespace FullFraim.Models.Dto_s.Photos
{
    public class ContestSubmissionOutputDto
    {
        public int PhotoId { get; set; }
        public string AuthorName { get; set; }
        public string PhotoTitle { get; set; }
        public string PhotoUrl { get; set; }
        public string Description { get; set; }
        public ICollection<ReviewDto> Reviews { get; set; }
    }
}
