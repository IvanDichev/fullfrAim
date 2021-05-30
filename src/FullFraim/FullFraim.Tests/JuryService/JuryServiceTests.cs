using FullFraim.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utilities.TestingUtils;

namespace FullFraim.Tests.JuryService
{
    [TestClass]
    public class JuryServiceTests
    {
        [TestMethod]
        public async Task HasJuryAlreadyGivenReview_ShouldReturnTrue()
        {
            //Arrange
            var options = TestUtils
                .GetInMemoryDatabaseOptions<FullFraimDbContext>
                (nameof(HasJuryAlreadyGivenReview_ShouldReturnTrue));

            using (var dbContext = new FullFraimDbContext(options))
            {

                await dbContext.SaveChangesAsync();
            }

            using (var context = new DeliverITContext(options))
            {
                var cityService = new CityService(context);

                var param = new PaginationParams();

                //Act
                var cities = await cityService.GetAllAsync(param);

                //Assert
                Assert.AreEqual(Util.GetCities().Count, cities.Count);

                context.Database.EnsureDeleted();
            }
        }
    }
}
