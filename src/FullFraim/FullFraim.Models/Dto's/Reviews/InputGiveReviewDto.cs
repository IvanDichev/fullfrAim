using System.ComponentModel.DataAnnotations;

namespace FullFraim.Models.Dto_s.Reviews
{
    public class InputGiveReviewDto
    {
        [Required]
        public string Comment { get; set; }

        [Required]
        [Range(1, 10)]
        public uint Score { get; set; }
        public bool Checkbox { get; set; }
        public int PhotoId { get; set; }
        public int JuryId { get; set; }
    }
}
