using System;

namespace FullFraim.Models.ViewModels.Dashboard
{
    public class ContestViewModel
    {
        //public int TestProperty { get; set; }
        //public List<string> TestListProperty { get; set; }

        public string Name { get; set; }

        public string Cover_Url { get; set; }

        public string Description { get; set; }

        public string Phase { get; set; }

        public string ContestCategory { get; set; }
        public DateTime EndDate { get; set; }

        //public string ContestType { get; set; }

    }

}
