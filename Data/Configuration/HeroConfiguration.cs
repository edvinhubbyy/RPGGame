using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RPGGame.Models.Models;

namespace RPGGame.Data.Configuration
{
    public class HeroConfiguration : IEntityTypeConfiguration<HeroModel>
    {
        public void Configure(EntityTypeBuilder<HeroModel> builder)
        {
            builder.HasKey(h => h.Id);
        }
    }
}
