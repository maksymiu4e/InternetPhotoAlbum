using DAL.Configurations;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //foreach (var foreingKey in builder.Model.GetEntityTypes()
            //    .SelectMany(e => e.GetForeignKeys()))
            //{
            //    foreingKey.DeleteBehavior = DeleteBehavior.Restrict;
            //}
            //builder.Entity<User>()
            //    .HasMany(p => p.Photos)
            //    .WithMany(p => p.Likes).Using

            builder.ApplyConfiguration(new PhotoConfiguration());

            builder.ApplyConfiguration(new UserConfiguration());

            builder.ApplyConfiguration(new LikeConfiguration());


            builder.Seed();
        }
    }
}
