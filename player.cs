namespace project1
{
    public class player : GameObject
        {
            
            int xdirection = 1;
            public void Move(int xstep, int ystep)
            {
                if(Program.CanMoveToDestination(x+xstep, y+ystep))
                {
                    x += xstep;
                    y += ystep;
                }
            }
            public void movebackandforth()
            {
                if(!Program.CanMoveToDestination(x+xdirection,y))
                {
                    xdirection*=-1;
                }
                Move(xdirection, 0);
            }
            public void MoveTowardsObject(GameObject obj)
            {
                if(obj.x>x)
                    Move(+1 , 0);
                else
                    Move(-1, 0);
                if(obj.y>y)
                    Move(0, +1);
                else
                    Move(0, -1);
            }
        }
}
