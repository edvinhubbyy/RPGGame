using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class MageEntity : HeroEntity
    {
        public MageEntity()
        {
            CharacterType = CharacterType.Mage;
            Strength = 2;
            Agility = 1;
            Intelligence = 3;
            Range = 3;
            Symbol = "*";
            Setup();
        }
    }
}
