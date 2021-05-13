using System;
using System.ComponentModel.DataAnnotations;

namespace PhotoContest.Data.Base
{
    public class BaseEntity<T> : IModifiable, IBaseEntity<T>
    {
        [Key]
        public T Id { get; set; }

        //Vanka: Triabva li da e required :D
        [Required]
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
