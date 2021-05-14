﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhotoContest.Data.Models;
using System.Reflection;

namespace PhotoContest.Data
{
    public class PCDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public PCDbContext(DbContextOptions<PCDbContext> options)
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
