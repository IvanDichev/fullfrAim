namespace FullFraim.Models.Dto_s.PhotoReview
{
    public class PhotoReviewModel
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public uint Score { get; set; }
        public bool Checkbox { get; set; }
        public int PhotoId { get; set; }
        public int JuryContestId { get; set; }
    }
}
