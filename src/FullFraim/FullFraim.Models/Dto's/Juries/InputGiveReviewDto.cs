namespace FullFraim.Models.Dto_s.Juries
{
    public class InputGiveReviewDto
    {
        public int UserId { get; set; }
        public string Comment { get; set; }
        public uint Score { get; set; }
        public bool Checkbox { get; set; }
        public int PhotoId { get; set; }
        public int JuryContestUserId { get; set; }
    }
}
