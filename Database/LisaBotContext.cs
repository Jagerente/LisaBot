using Microsoft.EntityFrameworkCore;

using LisaBot.Database.Configuration;
using LisaBot.Models;
using LisaBot.Models.Guides;

namespace LisaBot.Database
{
    public class LisaBotContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Guide> Guides { get; set; }
        //public DbSet<Tag> Tags { get; set; }

        public LisaBotContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql($"Host={Bot.DbConfig.Host};Port={Bot.DbConfig.Port};Database={Bot.DbConfig.Database};Username={Bot.DbConfig.Username};Password={Bot.DbConfig.Password};Pooling=True;SSL Mode=Require;TrustServerCertificate=True;");
            //optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=lisabot;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new GuideConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            //modelBuilder.ApplyConfiguration(new TagConfiguration());

            //modelBuilder.Entity<TagCategory>()
            //    .HasKey(tc => new { tc.TagId, tc.CategoryId });

            //modelBuilder.Entity<TagCategory>()
            //    .HasOne(tc => tc.Category)
            //    .WithMany(c => c.CategoryTags)
            //    .HasForeignKey(tg => tg.CategoryId);

            //modelBuilder.Entity<TagCategory>()
            //    .HasOne(tc => tc.Tag)
            //    .WithMany(t => t.RelatedCategories)
            //    .HasForeignKey(tc => tc.TagId);


            //modelBuilder.Entity<TagGuide>()
            //    .HasKey(tg => new { tg.TagId, tg.GuideId });

            //modelBuilder.Entity<TagGuide>()
            //    .HasOne(tg => tg.Guide)
            //    .WithMany(g => g.GuideTags)
            //    .HasForeignKey(tg => tg.GuideId);

            //modelBuilder.Entity<TagGuide>()
            //    .HasOne(tg => tg.Tag)
            //    .WithMany(t => t.RelatedGuides)
            //    .HasForeignKey(tg => tg.TagId);
        }
    }
}