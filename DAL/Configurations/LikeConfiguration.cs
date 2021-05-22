using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configurations
{
    public class LikeConfiguration : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.ToTable("Likes");
            builder
                .HasKey(m => m.Id);
            builder
                .HasOne(m => m.Photo).WithMany(x => x.Likes).HasForeignKey(x => x.PhotoId);
        }
    }
}
