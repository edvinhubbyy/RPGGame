using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RPGGame.Program
{
    public static class CharacterSelect
    {
        public static HeroEntity Result()
        {
            Console.Clear();
            Console.WriteLine("Choose character type:");
            Console.WriteLine("Options:");
            Console.WriteLine("1) Warrior (@)");
            Console.WriteLine("2) Archer (#)");
            Console.WriteLine("3) Mage (*)");
            Console.Write("Your pick: ");
            string input = Console.ReadLine();

            int strength = 0, agility = 0, intelligence = 0, range = 1;
            string name = "Hero";
            string symbol = "?";

            switch (input)
            {
                case "1":
                    name = "Warrior";
                    strength = 3;
                    agility = 3;
                    intelligence = 0;
                    range = 1;
                    symbol = "@";
                    break;
                case "2":
                    name = "Archer";
                    strength = 2;
                    agility = 4;
                    intelligence = 0;
                    range = 2;
                    symbol = "#";
                    break;
                case "3":
                    name = "Mage";
                    strength = 2;
                    agility = 1;
                    intelligence = 3;
                    range = 3;
                    symbol = "*";
                    break;
                default:
                    Console.WriteLine("Invalid choice. Defaulting to Warrior.");
                    name = "Warrior";
                    strength = 3;
                    agility = 3;
                    intelligence = 0;
                    range = 1;
                    symbol = "@";
                    break;
            }

            int health = strength * 5;
            int mana = intelligence * 3;

            StatBuffScreen.Result(ref strength, ref agility, ref intelligence);

            health = strength * 5;
            mana = intelligence * 3;
            int damage = agility * 2;

            var hero = new HeroEntity
            {
                Id = Guid.NewGuid(),
                Name = name,
                Strength = strength,
                Agility = agility,
                Intelligence = intelligence,
                Range = range,
                Symbol = symbol,
                Health = health,
                Mana = mana,
                Damage = damage,
                CreatedAt = DateTime.Now
            };

            Console.WriteLine($"\nYour hero is ready!");
            Console.WriteLine($"Type: {name} {symbol}");
            Console.WriteLine($"Strength: {hero.Strength}, Agility: {hero.Agility}, Intelligence: {hero.Intelligence}, Range: {hero.Range}");
            Console.WriteLine($"Health: {hero.Health}, Mana: {hero.Mana}");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();

            return hero;
        }
    }
}
