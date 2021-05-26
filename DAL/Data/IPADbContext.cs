using DAL.Configurations;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Data
{
    public class IPADbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public override DbSet<User> Users { get; set; }
        //public DbSet<UserProfile> UserProfiles { get; set; }
        //public DbSet<Role> Roles { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Like> Likes { get; set; }

        public IPADbContext(DbContextOptions<IPADbContext> options) : base(options)
        {
            // Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PhotoConfiguration());

            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.ApplyConfiguration(new LikeConfiguration());
        }
    }
}
