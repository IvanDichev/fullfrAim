using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhotoContest.Data.Models;

namespace PhotoContest.Data
{
    public class PCDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public PCDbContext(DbContextOptions<PCDbContext> options)
            : base(options) { }


    }
}
