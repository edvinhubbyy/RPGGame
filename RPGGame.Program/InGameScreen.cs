using Entities.Entities;
using RPGGame.Data;
using RPGGame.Models.Models;

namespace RPGGame.Program
{
    public static class InGameScreen
    {
        const int MatrixSize = 10;
        static readonly Random random = new Random();

        public static void Result(HeroEntity hero)
        {
            // For displaying Unicode characters correctly in my console 
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int heroX = 1, heroY = 1;
            var monsters = new List<MonsterEntity>();
            int monstersKilled = 0;

            while (hero.Health > 0)
            {
                SpawnMonster(monsters, heroX, heroY);

                DrawBoard(hero, heroX, heroY, monsters);

                var action = GetPlayerAction();
                if (action == "1")
                {
                    (heroX, heroY) = MoveHero(heroX, heroY);
                }
                else
                {
                    monstersKilled += HandleAttack(hero, heroX, heroY, monsters);
                }

                HandleMonsterTurn(monsters, hero, heroX, heroY);
            }

            Console.WriteLine($"\nGame over! Monsters killed: {monstersKilled}");
            SaveResults(hero, monsters, monstersKilled);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void SpawnMonster(List<MonsterEntity> monsters, int heroX, int heroY)
        {
            MonsterEntity monster;
            do
            {
                monster = new MonsterEntity
                {
                    X = random.Next(0, MatrixSize),
                    Y = random.Next(0, MatrixSize),
                    Health = 10,
                    Damage = 3
                };
            } while ((monster.X == heroX && monster.Y == heroY) ||
                     monsters.Any(m => m.X == monster.X && m.Y == monster.Y));
            monsters.Add(monster);
        }

        private static void DrawBoard(HeroEntity hero, int heroX, int heroY, List<MonsterEntity> monsters)
        {
            Console.Clear();
            Console.WriteLine($"Health: {hero.Health}    Mana: {hero.Mana}\n");

            for (int y = 0; y < MatrixSize; y++)
            {
                for (int x = 0; x < MatrixSize; x++)
                {
                    if (y == heroY && x == heroX)
                        Console.Write(hero.Symbol);
                    else if (monsters.Any(m => m.X == x && m.Y == y && m.Health > 0))
                        Console.Write("◙");
                    else
                        Console.Write('▒');
                }
                Console.WriteLine();
            }
        }

        private static string GetPlayerAction()
        {
            Console.WriteLine("\nChoose action: (1) Move  (2) Attack");
            string action = Console.ReadLine();
            while (action != "1" && action != "2")
            {
                Console.WriteLine("Please enter 1 or 2:");
                action = Console.ReadLine();
            }
            return action;
        }

        private static (int newX, int newY) MoveHero(int heroX, int heroY)
        {
            Console.WriteLine("Move options: W (up), S (down), D (right), A (left), E (up-right), X (down-right), Q (up-left), Z (down-left)");
            Console.Write("Enter move: ");
            var move = Console.ReadKey(true).Key;

            int newX = heroX, newY = heroY;
            switch (move)
            {
                case ConsoleKey.W:
                {
                    newY--; 
                    
                    break;
                }
                case ConsoleKey.S:
                {
                    newY++; 
                    break;
                }
                case ConsoleKey.A:
                {
                    newX--; 
                    break;
                }
                case ConsoleKey.D:
                {
                    newX++; 
                    break;
                }
                case ConsoleKey.Q:
                {
                    newY--; 
                    newX--; 
                    break;
                }
                case ConsoleKey.E:
                {
                    newY--; 
                    newX++; 
                    break;
                }
                case ConsoleKey.Z:
                {
                    newY++; 
                    newX--; 
                    break;
                }
                case ConsoleKey.X:
                {
                    newY++; 
                    newX++; 
                    break;
                }
                default:
                    Console.WriteLine("Invalid move key. Press any key...");
                    Console.ReadKey();
                    return (heroX, heroY);
            }

            if (newX >= 0 && newX < MatrixSize && newY >= 0 && newY < MatrixSize)
            {
                return (newX, newY);
            }

            return (heroX, heroY);
        }

        private static int HandleAttack(HeroEntity hero, int heroX, int heroY, List<MonsterEntity> monsters)
        {
            var targets = monsters
                .Where(m => m.Health > 0 && Math.Max(Math.Abs(m.X - heroX), Math.Abs(m.Y - heroY)) <= hero.Range)
                .ToList();

            if (targets.Count == 0)
            {
                Console.WriteLine("No available targets in your range. Press any key...");
                Console.ReadKey();
                return 0;
            }

            Console.WriteLine("Choose target to attack:");
            for (int i = 0; i < targets.Count; i++)
            {
                Console.WriteLine($"{i + 1}) Monster at ({targets[i].X + 1},{targets[i].Y + 1}) - HP: {targets[i].Health}");
            }

            int chosen = -1;
            while (chosen < 1 || chosen > targets.Count)
            {
                Console.Write("Pick number: ");
                int.TryParse(Console.ReadLine(), out chosen);
            }

            var target = targets[chosen - 1];
            target.Health -= hero.Damage;

            Console.WriteLine($"You hit monster for {hero.Damage} damage! It has {target.Health} HP left.");
            if (target.Health <= 0)
            {
                Console.WriteLine("Monster killed!");
                Console.ReadKey();
                return 1;
            }

            Console.ReadKey();
            return 0;
        }

        private static void HandleMonsterTurn(List<MonsterEntity> monsters, HeroEntity hero, int heroX, int heroY)
        {
            foreach (var m in monsters.Where(m => m.Health > 0))
            {
                int dist = Math.Max(Math.Abs(m.X - heroX), Math.Abs(m.Y - heroY));
                if (dist == 1)
                {
                    hero.Health -= m.Damage;
                    Console.WriteLine($"Monster at ({m.X + 1},{m.Y + 1}) hits you for {m.Damage}!");
                    if (hero.Health <= 0) break;
                }
                else
                {
                    m.Y += Math.Sign(heroY - m.Y);
                    m.X += Math.Sign(heroX - m.X);
                }
            }
        }

        private static void SaveResults(HeroEntity hero, List<MonsterEntity> monsters, int monstersKilled)
        {
            using var db = new GameDbContext();

            var heroModel = new HeroModel
            {
                Id = hero.Id,
                Name = hero.Name,
                Strength = hero.Strength,
                Agility = hero.Agility,
                Intelligence = hero.Intelligence,
                Range = hero.Range,
                Symbol = hero.Symbol,
                CreatedAt = hero.CreatedAt,
            };
            db.Heroes.Add(heroModel);

            foreach (var monster in monsters)
            {
                db.Monsters.Add(new MonsterModel
                {
                    Id = monster.Id,
                    X = monster.X,
                    Y = monster.Y,
                    Health = monster.Health,
                    Damage = monster.Damage
                });
            }

            db.Games.Add(new GameModel
            {
                HeroId = hero.Id,
                MonstersKilled = monstersKilled,
                StartedAt = DateTime.Now
            });

            db.SaveChanges();
        }
    }
}