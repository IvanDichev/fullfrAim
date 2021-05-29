using FullFraim.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utilities.TestingUtils;

namespace FullFraim.Tests.ScoringService
{
    [TestClass]
    public class ScoringServiceTests
    {
        [TestMethod]
        public async Task CalculateUserScore_Should_CorrectlyCalculateScore()
        {
            //Arrange
            var options = TestUtils
                .GetInMemoryDatabaseOptions<FullFraimDbContext>(nameof(CalculateUserScore_Should_CorrectlyCalculateScore));

            using (var dbContext = new FullFraimDbContext(options))
            {
                
            }


        }
    }
}
