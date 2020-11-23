using System;
using System.Text;
using System.Threading;
using System.Collections.Generic;

namespace project1
{
    class Program
    {
        public static readonly Random _random = new Random();
        public static int SCR_HEIGHT = 25;
        public static int SCR_WIDTH = 25;
        public static Player player1 = new Player();
        
        public static List<char> PassableObjects = new List<char>();
        public static StringBuilder screen = new StringBuilder(SCR_HEIGHT*SCR_WIDTH);
        public static char [,] screen2d = new char[SCR_WIDTH,SCR_HEIGHT];

        public static Dictionary <int, GameObject> Objects = new Dictionary<int, GameObject>();
        
        static void Main(string[] args)
        {
            LoadCollisions();
            Objects.Add(Objects.Count, player1);
            for (int i = 0; i < 3; i++)
            {
                Objects.Add(Objects.Count, new Zombie(_random.Next(1, SCR_WIDTH-2), _random.Next(1, SCR_HEIGHT -1)));
            }
            player1.setposition(10,10);
            Camp MainCamp = new Camp(_random.Next(1, SCR_WIDTH-2), _random.Next(1, SCR_HEIGHT -1));
            Tree sometree = new Tree(_random.Next(1, SCR_WIDTH-2), _random.Next(1, SCR_HEIGHT -1));
            Objects.Add(Objects.Count, sometree);
            Objects.Add(Objects.Count, MainCamp);
            
            while(true)
            {          
                if(Console.KeyAvailable)
                input();
                update();
                clear();
                draw();
                Thread.Sleep(50);
            }
        }
        public static void input()
        {
            //event
            
            ConsoleKey input;
            input = Console.ReadKey().Key;
            switch (input)
            {
                case ConsoleKey.D:
                    player1.Move(1,0);
                break;
                case ConsoleKey.A:
                    player1.Move(-1,0);
                break;
                case ConsoleKey.W:
                    player1.Move(0,-1);
                break;
                case ConsoleKey.S:
                    player1.Move(0,+1);
                break;
                default:
                break;
            }
        }
        
        private static void update()
        {
            //player1.movebackandforth();
            foreach (var kvp in Objects)
            {
                if(kvp.Value.type=="Zombie")
                    kvp.Value.MoveTowardsObject(player1);
            }
        
        }
        private static void clear()
        {
            clear2dbuffer('.');

            Console.Clear();
            screen.Clear();
        }
        private static void draw()
        {
            //draw room(rectangle)
            //drawRect(5,3,20,20);
            drawRect(0, 0, SCR_WIDTH-1, SCR_HEIGHT);
            foreach (var kvp in Objects)
            {
                kvp.Value.draw();
            }

            //render
            for (int j = 0; j < SCR_HEIGHT; j++)
            {
                for (int i = 0; i < SCR_WIDTH; i++)
                {
                    screen.Append(screen2d[i,j]);
                }
            }
            Console.Write(screen);
            
        }
        public static void drawRect(int x, int y, int w, int h)
        {
            for (int j = y; j < h; j++)
            {
                if(j==y||j==h-1)
                    for (int i = x; i < w; i++)
                    {
                        screen2d[i,j]='#';
                    }
                else
                {
                    for (int i = y; i < w; i++)
                    {
                        if(i==x||i==w-1)
                            screen2d[i,j]='#';
                    }
                }
            }
        }
        
        private static void clear2dbuffer(char initchar)
        {
            for (int j = 0; j < SCR_HEIGHT; j++)
            {
                for (int i = 0; i < SCR_WIDTH; i++)
                {
                    if(i==SCR_WIDTH-1)
                        screen2d[i,j] = '\n';
                    else
                        screen2d[i,j]=initchar;
                }
            }
        }
        private static void LoadCollisions()
        {
            PassableObjects.Add('#');
            PassableObjects.Add('P');
            PassableObjects.Add('E');
            PassableObjects.Add('H');
            PassableObjects.Add('Z');
            PassableObjects.Add('S');
            PassableObjects.Add('T');
            PassableObjects.Add('C');
        }
    }
}