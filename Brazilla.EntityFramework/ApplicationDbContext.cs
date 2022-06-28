using Brazilla.Database.Entities;
using Brazilla.EntityFramework.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Brazilla.EntityFramework
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CoffeeBlendEntity> Blends { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<BlendTypeEntity> Types { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new BlendConfiguration());
            modelBuilder.ApplyConfiguration(new BlendTypeConfiguration());
        }
    }
}