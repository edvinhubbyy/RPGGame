namespace Entities.Entities
{
    public class HeroEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public CharacterType CharacterType { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }
        public int Range { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Damage { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Symbol { get; set; } = null!;

        public void Setup()
        {
            Health = Strength * 5;
            Mana = Intelligence * 3;
            Damage = Agility * 2;
        }
    }
}
