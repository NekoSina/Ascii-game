using AsciiGame.AI;

namespace AsciiGame.Entities
{
    public class GameObject
    {
        public int Id;
        public char Character;
        public int X = 0;
        public int Y = 0;
        public Brain Brain;
        public Inventory Inventory;

        public GameObject()
        {
            Id = Program.CurrentMap.Objects.Count;
            Inventory = new Inventory();
            Brain = new NullBrain(this);
        }
        public virtual void Update()
        {
            Brain.Update();
        }
        public void Move(int xstep, int ystep)
        {
            if (!Program.CurrentMap.IsAccessible(X + xstep, Y + ystep))
                return;

            X += xstep;
            Y += ystep;
        }
        public void MoveTowardsObject(GameObject obj)
        {
            var deltaX = 0;
            var deltaY = 0;
            if (obj.X != X)
            {
                if (obj.X > X)
                    deltaX ++;
                else
                    deltaX --;
            }
            if (obj.Y != Y)
            {
                if (obj.Y > Y)
                    deltaY ++;
                else
                    deltaY --;
            }
            Move(deltaX,deltaY);
        }
    }
}