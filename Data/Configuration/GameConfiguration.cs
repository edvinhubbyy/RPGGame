using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RPGGame.Data.Configuration
{
    public class GameConfiguration : IEntityTypeConfiguration<GameModel>
    {
        public void Configure(EntityTypeBuilder<GameModel> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.StartedAt).IsRequired();

            builder.HasOne(g => g.Hero)
                .WithMany()
                .HasForeignKey(g => g.HeroId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
