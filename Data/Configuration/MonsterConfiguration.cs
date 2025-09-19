using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RPGGame.Models.Models;

namespace RPGGame.Data.Configuration
{
    public class MonsterConfiguration : IEntityTypeConfiguration<MonsterModel>
    {
        public void Configure(EntityTypeBuilder<MonsterModel> builder)
        {

            builder.HasKey(m => m.Id);

            builder.Property(m => m.X)
                .IsRequired();

            builder.Property(m => m.Y)
                .IsRequired();

            builder.Property(m => m.Health)
                .IsRequired();

            builder.Property(m => m.Damage)
                .IsRequired();

        }
    }
}
