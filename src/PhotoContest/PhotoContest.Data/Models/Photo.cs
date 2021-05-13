using PhotoContest.Data.Base;

namespace PhotoContest.Data.Models
{
    public class Photo : DeletableEntity<int>
    {
        //TODO: IMPLEMENT IMG_URL or Cloudinary :D VANKA 

        public int UserId { get; set; }
        public User User { get; set; }

        public int ContestId { get; set; }
        public Contest Contest { get; set; }
    }
}
