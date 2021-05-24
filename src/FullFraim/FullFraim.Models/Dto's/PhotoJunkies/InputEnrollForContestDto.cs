namespace FullFraim.Models.Dto_s.PhotoJunkies
{
    public class InputEnrollForContestDto
    {
        public int UserId { get; set; }
        public int ContestId { get; set; }
        public string ImageUrl { get; set; }
        public string ImageDescription { get; set; }
        public string ImageTitle { get; set; }
    }
}
