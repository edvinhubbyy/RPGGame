namespace RPGGame.Program
{
    public static class StatBuffScreen
    {
        public static void Result(ref int strength, ref int agility, ref int intelligence)
        {
            Console.Clear();
            Console.WriteLine("Would you like to buff up your stats before starting? (Limit: 3 points total)");
            Console.Write("Response (Y/N): ");
            var response = Console.ReadLine()?.Trim().ToUpper();
            if (response != "Y")
            {
                return;
            }

            int remainingPoints = 3;

            var stats = new Dictionary<string, int>
            {
                { "Strength", 0 },
                { "Agility", 0 },
                { "Intelligence", 0 }
            };

            foreach (var stat in stats.Keys.ToList())
            {
                if (remainingPoints == 0) break;

                Console.Write($"Add to {stat} (0-{remainingPoints}): ");

                if (int.TryParse(Console.ReadLine(), out int value) && value >= 0 && value <= remainingPoints)
                {
                    stats[stat] = value;
                    remainingPoints -= value;
                }
            }

            strength += stats["Strength"];
            agility += stats["Agility"];
            intelligence += stats["Intelligence"];

            Console.WriteLine("\nYour stats are now:");
            Console.WriteLine($"Strength: {strength}, Agility: {agility}, Intelligence: {intelligence}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}