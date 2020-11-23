using AsciiGame.Entities;

namespace AsciiGame
{
    public class Camp : GameObject
    {
        public Camp(int _x, int _y)
        {
            X = _x;
            Y = _y;
            Stockpile.wood = 50;
            Stockpile.stone = 50;
            Character = 'C';
        }
        Resource Stockpile = new Resource();
    }
}