using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FullFraim.Data.Models;
using System.Reflection;

namespace FullFraim.Data
{
    public class FullFraimDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public FullFraimDbContext(DbContextOptions<FullFraimDbContext> options)
            : base(options) { }

        public DbSet<Contest> Contests { get; set; }
        public DbSet<ContestCategory> ContestCategories { get; set; }
        public DbSet<ContestType> ContestTypes { get; set; }
        public DbSet<Phase> Phases { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<PhotoReview> PhotoReviews { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
