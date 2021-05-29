using Microsoft.EntityFrameworkCore;

namespace Utilities.TestingUtils
{
    public class TestUtils
    {
        public static DbContextOptions<T> GetInMemoryDatabaseOptions<T>(string dbName)
            where T : DbContext
        {
            var options = new DbContextOptionsBuilder<T>()
                .UseInMemoryDatabase(dbName)
                .Options;

            return options;
        }
    }
}
