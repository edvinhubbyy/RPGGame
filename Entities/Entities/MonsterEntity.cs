namespace Entities.Entities
{
    public class MonsterEntity
    {
        public Guid Id { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }
        public int Range { get; set; } = 1;
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Damage { get; set; }
        public string Symbol { get; set; } = "◙";
        public int X { get; set; }
        public int Y { get; set; }

        public MonsterEntity()
        {
            var rand = new Random();
            Strength = rand.Next(1, 4);
            Agility = rand.Next(1, 4);
            Intelligence = rand.Next(1, 4);
            Setup();
        }

        public void Setup()
        {
            Health = Strength * 5;
            Mana = Intelligence * 3;
            Damage = Agility * 2;
        }
    }
}
