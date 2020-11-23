namespace project1
{
    public class GameObject
    {
        public string type;
        public int ID;
        public char character;
        public int x = 0;
        public int y = 0;
        
        public void setposition(int _x, int _y)
            {
                x = _x;
                y = _y;
            }
        public void Move(int xstep, int ystep)
            {
                if(CanMoveToDestination(x+xstep, y+ystep))
                {
                    x += xstep;
                    y += ystep;
                }
            }
        public void MoveTowardsObject(GameObject obj)
            {
                
                if(obj.x>x+3)
                    Move(+1 , 0);
                else
                if(obj.x<x-3)
                    Move(-1, 0);
                if(obj.y>y+2)
                    Move(0, +1);
                else
                if(obj.y<y-2)
                    Move(0, -1);
            }
        int xdirection = 1;
        public void movebackandforth()
            {
                if(!CanMoveToDestination(x+xdirection,y))
                {
                    xdirection*=-1;
                }
                Move(xdirection, 0);
            }
        public void draw()
        {
            Program.screen2d[x, y]=character;
        }   
        public static bool CanMoveToDestination(int destX, int destY)
        {
            bool p = true;
            foreach (var item in Program.PassableObjects)
            {
                if(Program.screen2d[destX,destY] == item)
                    p = false;
            }
            
            return p;
        } 
    }

}