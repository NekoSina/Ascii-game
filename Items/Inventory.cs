using System;
using System.Collections.Generic;

namespace AsciiGame
{
    public class Inventory
    {
        private Dictionary<string, Item> Items;

        public Inventory()
        {
            Items = new Dictionary<string, Item>();
        }

        public void AddItem(string name, int count)
        {
            if (Contains(name))
                Items[name].Quantity += count;
            else
                Items.Add(name, new Item(name, count));
        }
        public void RemoveItem(string name, int count)
        {
            var item = Items[name];
            if (item.Quantity > 1)
                item.Quantity--;
            else
                Items.Remove(name);
        }
        public bool Contains(string name)
        {
            return Items.ContainsKey(name);
        }
        public Item GetItem(string name)
        {
            return Items[name];
        }
    }
}