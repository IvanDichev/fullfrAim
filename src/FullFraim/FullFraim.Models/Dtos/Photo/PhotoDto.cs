using System.Collections.Generic;

namespace FullFraim.Models.Dtos.Photo
{
    public class PhotoDto
    {
        public int Id { get; set; }
        public string PhotoUrl { get; set; }
        public string PhotoName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}