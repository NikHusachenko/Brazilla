using Brazilla.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Brazilla.EntityFramework.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users").HasKey(user => user.Id);

            builder.Property(user => user.Email).HasMaxLength(31).IsRequired(true);
            builder.Property(user => user.Login).HasMaxLength(15).IsRequired(true);
            builder.Property(user => user.Password).HasMaxLength(15).IsRequired(true);
        }
    }
}