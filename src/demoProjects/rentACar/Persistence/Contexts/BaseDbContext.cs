using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Brand> Brands { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(b =>
            {
                b.ToTable("Brands").HasKey(b=>b.Id);
                b.Property(b => b.Id).HasColumnName("Id");
                b.Property(b=>b.Name).HasColumnName("Name");
            });

            Brand[] brandSeedData = { new(1, "Bmw"), new(2, "Mercedes") };
            modelBuilder.Entity<Brand>().HasData(brandSeedData);

        }
    }
}
