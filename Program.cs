using System;
using System.Text;
using System.Threading;
using System.Collections.Generic;
namespace project1
{
    class Program
    {
        //public static char ground=Convert.ToChar(176);
        public static int SCR_HEIGHT = 50;
        public static int SCR_WIDTH = 50;
        public static player player1 = new player();
        public static player enemy1 = new player();
        public static List<char> PassableObjects = new List<char>();
        public static StringBuilder screen = new StringBuilder(SCR_HEIGHT*SCR_WIDTH);
        public static char [,] screen2d = new char[SCR_WIDTH,SCR_HEIGHT];

        static void Main(string[] args)
        {
            player1.setposition(10,10);
            enemy1.setposition(30,30);
            PassableObjects.Add('#');
            PassableObjects.Add('e');
            PassableObjects.Add('h');
            PassableObjects.Add('z');
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
                if(CanMoveToDestination(player1.x+1, player1.y))
                    player1.Move(1,0);
                break;
                case ConsoleKey.A:
                if(CanMoveToDestination(player1.x-1, player1.y))
                    player1.Move(-1,0);
                break;
                case ConsoleKey.W:
                if(CanMoveToDestination(player1.x, player1.y-1))
                    player1.Move(0,-1);
                break;
                case ConsoleKey.S:
                if(CanMoveToDestination(player1.x, player1.y+1))
                    player1.Move(0,+1);
                break;
                default:
                break;
            }
        }
        public static void update()
        {
            enemy1.Move(1,0);
        }
        public static void clear()
        {
            clear2dbuffer('.');

            Console.Clear();
            screen.Clear();
        }
        public static void draw()
        {
            //draw room(rectangle)
            //drawRect(5,3,20,20);
            drawRect(0, 0, SCR_WIDTH-1, SCR_HEIGHT);
            drawObject('p', player1.x, player1.y);
            drawObject('e', enemy1.x, enemy1.y);
            

            //render
            for (int j = 0; j < SCR_HEIGHT; j++)
            {
                for (int i = 0; i < SCR_WIDTH; i++)
                {
                    screen.Append(screen2d[i,j]);
                }
            }
            Console.ResetColor();
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
        public static void drawObject(char obj, int x, int y)
        {
            screen2d[x, y]=obj;
        }
        public static bool CanMoveToDestination(int destX, int destY)
        {
            bool p = true;
            foreach (var item in PassableObjects)
            {
                if(screen2d[destX,destY] == item)
                    p = false;
            }
            
            return p;
        }
        public static void clear2dbuffer(char initchar)
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
    }
}