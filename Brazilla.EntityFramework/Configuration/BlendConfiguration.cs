using Brazilla.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Brazilla.EntityFramework.Configuration
{
    public class BlendConfiguration : IEntityTypeConfiguration<CoffeeBlendEntity>
    {
        public void Configure(EntityTypeBuilder<CoffeeBlendEntity> builder)
        {
            builder.ToTable("Blends").HasKey(blend => blend.Id);

            builder.Property(blend => blend.Description).HasMaxLength(255);
            builder.Property(blend => blend.Name).HasMaxLength(31);

            builder.HasOne<UserEntity>(blend => blend.User)
                .WithMany(user => user.Blends)
                .HasForeignKey(meat => meat.UserFK);
        }
    }
}