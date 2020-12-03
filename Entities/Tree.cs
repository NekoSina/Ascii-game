using AsciiGame.Entities;


namespace AsciiGame
{
    public class Tree : GameObject
    {
        public Item Wood = new Item("Wood", 5);
        public Tree(int _x, int _y)
        {
            X = _x;
            Y = _y;
            Character = 'T';
        }        
    }
}