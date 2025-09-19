using Entities.Entities;

namespace Entities.Entities
{
    public class ArcherEntity : HeroEntity
    {
        public ArcherEntity()
        {
            CharacterType = CharacterType.Archer;
            Strength = 2;
            Agility = 4;
            Intelligence = 0;
            Range = 2;
            Symbol = "#";
            Setup();
        }
    }
}
