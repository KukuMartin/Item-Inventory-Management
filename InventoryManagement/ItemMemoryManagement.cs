using System;
using InventoryManagement;
using Item_Inventory.InventoryObject;

namespace Item_Inventory.InventoryManagement {
    public class ItemMemoryManagement : ItemManagementFramework
    {
        private List<Item> items = new List<Item>() ;

        public void populate()
        {
            if(this.itemSize() != 0)
            {
                return;
            }

            this.itemAdd(new Item("Hammer", 1));
            this.itemAdd(new Item("Nails", 10));
            this.itemAdd(new Item("Cigarette", 500));
            this.itemAdd(new Item("Plank", 20));
            this.itemAdd(new Item("Glue", 25));
            this.itemAdd(new Item("Screw", 10));
        }

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

        public void itemUpdate(Item item, string newName, int newAmount)
        {
            item.name = newName;
            item.amount = newAmount;
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
