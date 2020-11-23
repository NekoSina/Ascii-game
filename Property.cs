namespace project1
{
    public class Tree : GameObject
    {
        public int wood;
        public Tree(int _x, int _y)
        {
            x = _x;
            y = _y;
            type = "Tree";
            character = 'T';
        }
        
    }
    public class Camp : GameObject
    {
        public Camp(int _x, int _y)
        {
            x = _x;
            y = _y;
            Stockpile.wood = 50;
            Stockpile.stone = 50;
            type = "Camp";
            character = 'C';
            Program.Objects.Add(Program.Objects.Count, this);
        }
        Resource Stockpile = new Resource();
        
    }
    public class Stone : GameObject
    {
        public int stone;

    }
}