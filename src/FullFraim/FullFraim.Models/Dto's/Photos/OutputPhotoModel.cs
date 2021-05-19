using FullFraim.Data.Models;

namespace FullFraim.Models.Dto_s.Photos
{
    public class OutputPhotoModel
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public ParticipantContest Participant { get; set; }
    }
}
