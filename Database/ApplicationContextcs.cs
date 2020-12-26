using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace LisaBot.Database
{
    class ApplicationContextcs : DbContext
    {
        public DbSet<Modules.Guides.Category> testTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=ec2-79-125-86-58.eu-west-1.compute.amazonaws.com;Port=5432;Database=daimtbvkhvhot9;Username=khufxmxobzwsda;Password=c7a77d3d8b006a0f8f85fa68d887f92bbb30e0d39ea8a744bad4e11c229972dd;Pooling=True;SSL Mode=Require;TrustServerCertificate=True;");

            
        }
        public ApplicationContextcs()
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>().ToTable("TestTable").HasKey(p => p.Id);
        }
    }

    class Test
    {
        public int Id { get; set; }

        public string testString { get; set; }
    }
}
