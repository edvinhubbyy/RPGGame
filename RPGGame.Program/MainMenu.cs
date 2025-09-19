namespace RPGGame.Program
{
    public static class MainMenu
    {
        public static void Result()
        {
            Console.Clear();
            Console.WriteLine("Welcome!");
            Console.WriteLine("Press any key to play.");
            Console.ReadKey();

            var hero = CharacterSelect.Result();
            InGameScreen.Result(hero);
        }
    }
}
