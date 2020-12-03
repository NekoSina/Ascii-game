namespace AsciiGame
{
    public class Item
    {
        public int Id;
        public string Name;
        public int Quantity;        
        
        public Item(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }
}