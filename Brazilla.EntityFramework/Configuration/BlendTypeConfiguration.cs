using Brazilla.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Brazilla.EntityFramework.Configuration
{
    public class BlendTypeConfiguration : IEntityTypeConfiguration<BlendTypeEntity>
    {
        public void Configure(EntityTypeBuilder<BlendTypeEntity> builder)
        {
            builder.ToTable("Blend types").HasKey(type => type.Id);

            builder.Property(type => type.Name).HasMaxLength(63);

            builder.HasMany<CoffeeBlendEntity>(type => type.Blends)
                .WithOne(blend => blend.Type)
                .HasForeignKey(blend => blend.TypeFK)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}