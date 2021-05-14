using System;

namespace PhotoContest.Data.Base
{
    public interface IModifiable
    {
        DateTime CreatedOn { get; set; }
        DateTime? ModifiedOn { get; set; }
    }
}
