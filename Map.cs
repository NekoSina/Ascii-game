using System.Collections.Generic;
using AsciiGame.Entities;

namespace AsciiGame
{
    public class Map
    {
        public int Width = 25;
        public int Height = 25;
        public char[,] Grid;
        public Dictionary<int, GameObject> Objects = new Dictionary<int, GameObject>();
        public static List<char> PassableObjects = new List<char>();

        public Map(int width, int height)
        {
            Width=width;
            Height=height;
            Grid = new char[width, height];
        }
        public void CreateRoom(int xStart, int yStart, int xEnd, int yEnd)
        {
            //var ds = Program.Rng.Next(0, 3); // Side to place the door at
            var ds = 3;
            var doorX = 0;
            var doorY = 0;
            switch (ds)
            {
                case 0: // top
                    doorY = yStart;
                    doorX = Program.Rng.Next(xStart + 2, xEnd - 2);
                    break;
                case 2: // bottom
                    doorY = yEnd - 1;
                    doorX = Program.Rng.Next(xStart + 2, xEnd - 2);
                    break;
                case 1: // right
                    doorY = Program.Rng.Next(yStart + 2, yEnd - 2);
                    doorX = xEnd - 1;
                    break;
                case 3: // left
                    doorY = Program.Rng.Next(yStart + 2, yEnd - 2);
                    doorX = xStart;
                    break;
            }
            var door = new Door();
            door.X = doorX;
            door.Y = doorY;
            var id = door.Id;
            Objects.Add(door.Id, door);

            for (int y = yStart; y < yEnd; y++)
            {
                for (int x = xStart; x < xEnd; x++)
                {
                    if (x == doorX && y == doorY)
                        continue;

                    if (y > yStart && y < yEnd - 1 && x > xStart && x < xEnd - 1)
                    {
                        var floor = new Floor();
                        floor.X = x;
                        floor.Y = y;
                        Objects.Add(floor.Id, floor);
                    }
                    else
                    {
                        var wall = new Wall();
                        wall.X = x;
                        wall.Y = y;
                        Objects.Add(wall.Id, wall);
                    }
                }
            }
        }

        internal void AddEnttiy(GameObject entity)
        {
            Objects.Add(entity.Id, entity);
        }  
        internal void RemoveEnttiy(GameObject entity)
        {
            Objects.Remove(entity.Id);
        }        
        public bool IsAccessible(int x, int y)
        {
            var c = Grid[x,y];
            if(PassableObjects.Contains(c))
                return true;
            return false;
        }
        public void LoadCollisions()
        {
            PassableObjects.Add('.');
            PassableObjects.Add(' ');
        }
    }
}