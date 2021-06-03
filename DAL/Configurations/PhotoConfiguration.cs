using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            builder
                .HasOne(m => m.User).WithMany(x => x.Photos).HasForeignKey(x => x.UserId);
        }
    }
}
