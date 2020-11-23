namespace project1
{
    public class Human : GameObject
    {
        public string Name;
        Resource inventory = new Resource();
        public Human()
        {
            character = 'H';
            type = "Human";
            inventory.wood = 5;
            inventory.stone = 5;
        }
    }
}