using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using LisaBot.Models.Guides;

namespace LisaBot.Database.Configuration
{
    public class GuideConfiguration : IEntityTypeConfiguration<Guide>
    {
        public void Configure(EntityTypeBuilder<Guide> builder)
        {
            builder.ToTable("Guides");

            builder.HasKey(g => g.Id);
            builder.Property(g => g.Title).IsRequired();
            //builder.HasIndex(g => g.Title);
            builder.Property(g => g.TagString).HasMaxLength(100);

            var ownedBuilder = builder.OwnsOne(g => g.Information);

            ownedBuilder.Property(i => i.Description)
                .HasColumnName("Description")
                .IsRequired();
            ownedBuilder.Property(i => i.IsEarlyAccess)
                .HasColumnName("EarlyAccess")
                .IsRequired();
            ownedBuilder.Property(i => i.IsPremium)
                .HasColumnName("Premium")
                .IsRequired();
            ownedBuilder.Property(i => i.Link)
                .HasColumnName("Link")
                .IsRequired();
        }
    }
}
