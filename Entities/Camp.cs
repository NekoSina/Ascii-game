using System.Collections.Generic;
using AsciiGame.Entities;

namespace AsciiGame
{
    public class Camp : GameObject
    {
        public List<string> DesiredResources = new List<string> { "Wood", "Stone" };
        public Camp(int _x, int _y)
        {
            X = _x;
            Y = _y;
            Character = 'C';
        }
    }
}