using AsciiGame.AI;

namespace AsciiGame.Entities
{
    public class Zombie : GameObject
    {
        public Zombie(int _x, int _y)
        {
            Brain = new ZombieBrain(this);
            X = _x;
            Y = _y;
            Character = 'Z';
        }
    }
}