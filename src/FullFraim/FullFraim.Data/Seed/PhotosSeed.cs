using FullFraim.Data.Models;
using Shared;
using System.Collections.Generic;

namespace FullFraim.Data.Seed
{
    public static class PhotosSeed
    {
        public static readonly List<Photo> SeedData = new List<Photo>()
        { 
            new Photo()
            {
                Id = 1,
                ContestId = 1,
                Title = "Squirrel",
                Story = "Looking down",
                Url = Constants.ImagesSeed.WildlifeImgUrl,
            },
            new Photo()
            {
                Id = 2,
                ContestId = 1,
                Title = "Bath time",
                Story = "On my way",
                Url = Constants.ImagesSeed.WildlifeImg2Url,
            },
            new Photo()
            {
                Id = 3,
                ContestId = 1,
                Title = "Fight in the night",
                Story = "Subway fighters",
                Url = Constants.ImagesSeed.WildlifeImg3Url,
            },
            new Photo()
            {
                Id = 4,
                ContestId = 1,
                Title = "I can climb it",
                Story = "Not a long way, we can climb it",
                Url = Constants.ImagesSeed.WildlifeImg4Url,
            },
            //new Photo()
            //{
            //    Id = 5,
            //    ContestId = 1,
            //    Title = "Can I have some?",
            //    Story = "Hungry birds",
            //    Url = Constants.ImagesSeed.WildlifeImg5Url,
            //},
            //new Photo()
            //{
            //    Id = 6,
            //    ContestId = 1,
            //    Title = "Got it!",
            //    Story = "Got it!",
            //    Url = Constants.ImagesSeed.WildlifeImg6Url,
            //},
            
            //new Photo()
            //{
            //    Id = 7,
            //    ContestId = 2,
            //    Title = "Squirrel",
            //    Story = "Looking down",
            //    Url = Constants.ImagesSeed.WildlifeImgUrl,
            //},
            //new Photo()
            //{
            //    Id = 8,
            //    ContestId = 2,
            //    Title = "Bath time",
            //    Story = "On my way",
            //    Url = Constants.ImagesSeed.WildlifeImg2Url,
            //},
            new Photo()
            {
                Id = 9,
                ContestId = 2,
                Title = "Fight in the night",
                Story = "Subway fighters",
                Url = Constants.ImagesSeed.WildlifeImg3Url,
            },
            new Photo()
            {
                Id = 10,
                ContestId = 2,
                Title = "I can climb it",
                Story = "Not a long way, we can climb it",
                Url = Constants.ImagesSeed.WildlifeImg4Url,
            },
            new Photo()
            {
                Id = 11,
                ContestId = 2,
                Title = "Can I have some?",
                Story = "Hungry birds",
                Url = Constants.ImagesSeed.WildlifeImg5Url,
            },
            new Photo()
            {
                Id = 12,
                ContestId = 2,
                Title = "Git It!",
                Story = "Got it!",
                Url = Constants.ImagesSeed.WildlifeImg6Url,
            },
            
            new Photo()
            {
                Id = 13,
                ContestId = 3,
                Title = "Squirrel",
                Story = "Looking down",
                Url = Constants.ImagesSeed.WildlifeImgUrl,
            },
            new Photo()
            {
                Id = 14,
                ContestId = 3,
                Title = "Bath time",
                Story = "On my way",
                Url = Constants.ImagesSeed.WildlifeImg2Url,
            },
            new Photo()
            {
                Id = 15,
                ContestId = 3,
                Title = "Fight in the night",
                Story = "Subway fighters",
                Url = Constants.ImagesSeed.WildlifeImg3Url,
            },
            new Photo()
            {
                Id = 16,
                ContestId = 3,
                Title = "I can climb it",
                Story = "Not a long way, we can climb it",
                Url = Constants.ImagesSeed.WildlifeImg4Url,
            },
            //new Photo()
            //{
            //    Id = 17,
            //    ContestId = 3,
            //    Title = "Can I have some?",
            //    Story = "Hungry birds",
            //    Url = Constants.ImagesSeed.WildlifeImg5Url,
            //},
            //new Photo()
            //{
            //    Id = 18,
            //    ContestId = 3,
            //    Title = "Got it!",
            //    Story = "Got it!",
            //    Url = Constants.ImagesSeed.WildlifeImg6Url,
            //},

            new Photo()
            {
                Id = 19,
                ContestId = 4,
                Title = "Smile",
                Story = "Just a nice picture",
                Url = Constants.ImagesSeed.PortraitImgUrlCover,
            }
        };
    }
}
