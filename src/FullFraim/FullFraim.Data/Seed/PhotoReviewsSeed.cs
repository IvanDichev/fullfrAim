using FullFraim.Data.Models;
using System.Collections.Generic;

namespace FullFraim.Data.Seed
{
    public static class PhotoReviewsSeed
    {
        public static readonly List<PhotoReview> SeedData = new List<PhotoReview>()
        {
            // Phase One - Cannot be given to the photos
            //new PhotoReview()
            //{
            //    Id = 1,
            //    JuryContestId = 1,
            //    PhotoId = 1,
            //    Score = 5,
            //    Comment = "nice",
            //},
            //new PhotoReview()
            //{
            //    Id = 2,
            //    JuryContestId = 1,
            //    PhotoId = 2,
            //    Score = 7,
            //    Comment = "good",
            //},
            //new PhotoReview()
            //{
            //    Id = 3,
            //    JuryContestId = 1,
            //    PhotoId = 3,
            //    Score = 9,
            //    Comment = "WOW",
            //},
            //new PhotoReview()
            //{
            //    Id = 4,
            //    JuryContestId = 1,
            //    PhotoId = 4,
            //    Score = 4,
            //    Comment = "nice",
            //},
            
            new PhotoReview()
            {
                Id = 5,
                JuryContestId = 1,
                PhotoId = 9,
                Score = 4,
                Comment = "nice",
            },
            new PhotoReview()
            {
                Id = 6,
                JuryContestId = 1,
                PhotoId = 10,
                Score = 10,
                Comment = "Extraordinary",
            },
            new PhotoReview()
            {
                Id = 7,
                JuryContestId = 1,
                PhotoId = 11,
                Score = 6,
                Comment = "nice",
            },
            new PhotoReview()
            {
                Id = 8,
                JuryContestId = 1,
                PhotoId = 12,
                Score = 6,
                Comment = "nice",
            },

            new PhotoReview()
            {
                Id = 9,
                JuryContestId = 1,
                PhotoId = 13,
                Score = 8,
                Comment = "nice",
            },
            new PhotoReview()
            {
                Id = 10,
                JuryContestId = 1,
                PhotoId = 14,
                Score = 4,
                Comment = "nice",
            },
            new PhotoReview()
            {
                Id = 11,
                JuryContestId = 1,
                PhotoId = 15,
                Score = 8,
                Comment = "nice",
            },
            new PhotoReview()
            {
                Id = 12,
                JuryContestId = 1,
                PhotoId = 16,
                Score = 5,
                Comment = "nice",
            },



        };
    }
}
