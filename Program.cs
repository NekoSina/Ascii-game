using System;
using System.Text;
using System.Threading;
using AsciiGame.Entities;

namespace AsciiGame
{
    class Program
    {
        public static StringBuilder Screen;
        public static Random Rng;
        public static Player Player;
        public static Map CurrentMap;

        static void Main(string[] args)
        { 
            Rng = new Random();

            CurrentMap = new Map(50,25);
            CurrentMap.CreateRoom(0, 0, CurrentMap.Width - 1, CurrentMap.Height-1);
            CurrentMap.LoadCollisions();
            Screen = new StringBuilder(CurrentMap.Width * CurrentMap.Height);

            Player = new Player();
            Player.X = 10;
            Player.Y = 10;
            CurrentMap.AddEnttiy(Player);

            for (int i = 0; i < 3; i++)
            {
                var zombieX = Rng.Next(1, CurrentMap.Width - 2);
                var zombieY = Rng.Next(1, CurrentMap.Height- 2);
                var zombie = new Zombie(zombieX,zombieY);
                CurrentMap.AddEnttiy(zombie);
            }
            
            var campX = Rng.Next(1, CurrentMap.Width - 2);
            var campY = Rng.Next(1, CurrentMap.Height- 2);
            var camp = new Camp(campX,campY);
            CurrentMap.AddEnttiy(camp);

            var sometreeX = Rng.Next(1, CurrentMap.Width - 2);
            var sometreeY = Rng.Next(1, CurrentMap.Height- 2);
            var sometree = new Tree(sometreeX,sometreeY);
            CurrentMap.AddEnttiy(sometree);

            while (true)
            {
                if (Console.KeyAvailable)
                    Input();

                Update();
                Draw();

                Thread.Sleep(50);
            }
        }
        public static void Input()
        {
            ConsoleKey input = Console.ReadKey().Key;
            switch (input)
            {
                case ConsoleKey.D:
                    Player.Move(1, 0);
                    break;
                case ConsoleKey.A:
                    Player.Move(-1, 0);
                    break;
                case ConsoleKey.W:
                    Player.Move(0, -1);
                    break;
                case ConsoleKey.S:
                    Player.Move(0, +1);
                    break;
                default:
                    break;
            }
        }

        private static void Update()
        {
            foreach (var kvp in CurrentMap.Objects)
            {
                if (kvp.Value is Zombie)
                    kvp.Value.MoveTowardsObject(Player);
            }
        }
        private static void Draw()
        {
            Console.Clear();
            Screen.Clear();

            foreach (var kvp in CurrentMap.Objects)
            {
                var gameObject = kvp.Value;
                CurrentMap.Grid[gameObject.X, gameObject.Y] = gameObject.Character;
            }
            
            for (int y = 0; y < CurrentMap.Height-1; y++)
            {
                for (int x = 0; x < CurrentMap.Width-1; x++)
                    Screen.Append(CurrentMap.Grid[x, y]);

                Screen.AppendLine();
            }
            Console.Write(Screen);
        }
    }
}