namespace AsciiGame.Entities
{
    public class Human : GameObject
    {
        public string Name;
        Resource inventory = new Resource();
        public Human()
        {
            Character = 'H';
            inventory.wood = 5;
            inventory.stone = 5;
        }
    }
}