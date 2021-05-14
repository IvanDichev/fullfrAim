using PhotoContest.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace PhotoContest.Data.Models
{
    public class UserContest : DeletableEntity<int>
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int ContestId { get; set; }
        public Contest Contest { get; set; }

        [Range(0, 10)]
        public uint Score { get; set; }
    }
}
