using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

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
                b.HasMany(b => b.Models);
            });

            modelBuilder.Entity<Model>(m =>
            {
                m.ToTable("Models").HasKey(b => b.Id);
                m.Property(m=>m.Id).HasColumnName("Id");
                m.Property(m => m.BrandId).HasColumnName("BrandId");
                m.Property(m=>m.Name).HasColumnName("Name");
                m.Property(m=>m.DailyPrice).HasColumnName("DailyPrice");
                m.Property(m => m.ImageUrl).HasColumnName("ImageUrl");
                m.HasOne(m => m.Brand);
            });

            Brand[] brandSeedData = { new(1, "Bmw"), new(2, "Mercedes") };
            modelBuilder.Entity<Brand>().HasData(brandSeedData);

            Model[] modelEntitySeeds =
            {
                new(1, 1, "Series 4", 1500, ""),
                new(2, 1, "Series 5", 1700, ""),
                new(3, 2, "Series C", 2000, ""),
            };
            modelBuilder.Entity<Model>().HasData(modelEntitySeeds);

        }
    }
}
