using AsciiGame.AI;
namespace AsciiGame.Entities
{
    public class Human : GameObject
    {
        public string Name;
        public Camp MyCamp;
        Resource inventory = new Resource();
        public Human(int _x, int _y, Camp camp)
        {
            MyCamp = camp;
            Brain = new HumanBrain(this);
            X = _x;
            Y = _y;
            Character = 'H';

        }
        public override void Update()
        {
            Brain.Update();
            base.Update();
        }
    }
}