using FullFraim.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace FullFraim.Data.Models
{
    public class UserContest : DeletableEntity<int>
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int ContestId { get; set; }
        public Contest Contest { get; set; }
    }
}
