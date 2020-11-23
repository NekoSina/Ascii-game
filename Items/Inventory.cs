using System.Collections.Generic;

namespace AsciiGame
{
    public class Inventory
    {
        private Dictionary<int, Item> Items;

        public Inventory()
        {
            Items = new Dictionary<int, Item>();
        }

        public void AddItem(Item item)
        {
            Items.Add(item.Id,item);
        }
        public void RemoveItem(Item item)
        {
            Items.Remove(item.Id);
        }
        public bool Contains(Item item)
        {
            return Items.ContainsKey(item.Id);
        }
    }
}