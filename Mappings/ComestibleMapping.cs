using crud.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace crud.Mapping
{
    public class ComestibleMapping : IEntityTypeConfiguration<Comestible>
    {
        public void Configure(EntityTypeBuilder<Comestible> builder)
        {
            builder.HasKey(c => c.id);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Description).IsRequired().HasMaxLength(500);
            builder.Property(c => c.CategoryName).IsRequired();
            builder
                .HasOne(c => c.Category)
                .WithMany(c=>c.Comestibles)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}