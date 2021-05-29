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
        public async Task GetAll_ShouldReturnAllJuries()
        {
            //Arrange
            var options = TestUtils
                .GetInMemoryDatabaseOptions<FullFraimDbContext>(nameof(GetAll_ShouldReturnAllJuries));

            using (var dbContext = new DeliverITContext(options))
            {
                dbContext.Countries.AddRange(Util.GetCountries());
                dbContext.Cities.AddRange(Util.GetCities());

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
