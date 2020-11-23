using AsciiGame.Entities;

namespace AsciiGame
{
    public class Tree : GameObject
    {
        public int wood;
        public Tree(int _x, int _y)
        {
            X = _x;
            Y = _y;
            Character = 'T';
        }        
    }
}