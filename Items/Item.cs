namespace AsciiGame
{
    public class Item
    {
        public Item(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
        public int Id;
        public string Name;
        public int Quantity;
    }
}