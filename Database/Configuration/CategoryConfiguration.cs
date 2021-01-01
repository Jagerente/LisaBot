using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using LisaBot.Models.Guides;

namespace LisaBot.Database.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Title).IsRequired();
            builder.Property(c => c.TagString).HasMaxLength(100);

            builder
                .HasMany(c => c.Guides)
                .WithOne(g => g.Category)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
