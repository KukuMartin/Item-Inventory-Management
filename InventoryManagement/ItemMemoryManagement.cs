using InventoryManagement;
using Item_Inventory.InventoryObject;
using System;
using System.Xml.Linq;

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
            return items.FirstOrDefault(item => item.name.ToLower() == name.ToLower());
        }

        public Item itemSearch(int index)
        {
            return items[index];
        }

        public bool itemExist(string name)
        {
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

        public List<Category> getAllCategory()
        {
            throw new NotImplementedException();
        }

        public Category getCategory(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public List<Item> getAllItem(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public Item getItem(Guid itemId)
        {
            throw new NotImplementedException();
        }

        public void addCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void addItem(Item item)
        {
            throw new NotImplementedException();
        }

        public void removeCategory(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public void removeItem(Guid itemId)
        {
            throw new NotImplementedException();
        }

        public bool CategoryExist(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public bool ItemExist(Guid itemId)
        {
            Item item = items.FirstOrDefault(item => item.id == itemId);
            return item != null;
        }
    }
}
