using System;
using Item_Inventory.InventoryObject;

namespace Item_Inventory.InventoryService
{
    public class ItemManagement
    {
        private List<Item> items = new List<Item>() ;


        public void itemAdd(Item item)
        {
            items.Add(item);
        }
        public void itemRemove(Item item)
        {
            items.Remove(item);
        }

        public Item itemSearch(string name)
        {
            return items.FirstOrDefault(item => item.name == name);
        }
        public Item itemSearch(int index)
        {
            return items[index];
        }

        public bool itemExist(string name)
        {
            Item item = items.FirstOrDefault(item => item.name == name);
            return item != null;
        }

        public void itemUpdate(Item item, string newName, int newAMount)
        {
            item.name = newName;
            item.amount = newAMount;
        }

        public void amountAdd(Item item, int amount)
        {
            item.amount += amount;
        }

        public void amountRemove(Item item, int amount)
        {
            item.amount -= amount;
        }
        public int itemSize()
        {
            return items.Count;
        }
        public List<Item> itemList()
        {
            return items;
        }
    }
}
