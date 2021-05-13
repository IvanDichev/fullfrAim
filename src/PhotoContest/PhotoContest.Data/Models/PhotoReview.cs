using PhotoContest.Data.Base;

namespace PhotoContest.Data.Models
{
    public class PhotoReview : DeletableEntity<int>
    {
        public int Score { get; set; }
        public int Comment { get; set; }
        public bool Checkbox { get; set; }

        public int PhotoId { get; set; }
        public Photo Photo { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
