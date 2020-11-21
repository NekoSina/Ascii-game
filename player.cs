namespace project1
{
    public class player : GameObject
        {
            
            char character = 'p';
            public void Move(int destx, int desty)
            {
                if(Program.CanMoveToDestination(x+destx, y+desty))
                {
                    x += destx;
                    y += desty;
                }
            }
        }
}
