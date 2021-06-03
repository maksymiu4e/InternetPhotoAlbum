using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configurations
{
    public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.ToTable("Photos");
            builder
                .HasKey(m => m.Id);
            builder
                .Property(m => m.Id).ValueGeneratedOnAdd();
            builder
                .Property(m => m.CreationDate).IsRequired();
            builder
                .Property(m => m.Content).IsRequired();
            builder
                .Property(m => m.Title).IsRequired();
            //builder
            //    .HasMany(m => m.Likes).WithOne(x => x.Photo).HasForeignKey(x => x.PhotoId);
            builder
                .HasOne(m => m.User).WithMany(x => x.Photos).HasForeignKey(x => x.UserId);
        }
    }
}
