using crud.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace crud.Mapping
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CategoryName).HasMaxLength(300).IsRequired();
            builder.HasIndex(c => c.CategoryName).IsUnique();
            builder.Property(c => c.Comestibles).HasMaxLength(600).IsRequired();
        }
    }
}