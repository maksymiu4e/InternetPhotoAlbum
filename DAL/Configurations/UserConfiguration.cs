using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder
                .HasKey(m => m.Id);
            builder
                .Property(m => m.Id).ValueGeneratedOnAdd();
            builder
                .Property(m => m.FirstName);
            builder
                .Property(m => m.LastName);
            //builder
            //    .HasMany(m => m.Photos).WithOne(x => x.User).HasForeignKey(x => x.UserId);
            //builder
            //    .HasMany(m => m.Likes).WithOne(x => x.User).HasForeignKey(x => x.UserId);

        }
    }
}
