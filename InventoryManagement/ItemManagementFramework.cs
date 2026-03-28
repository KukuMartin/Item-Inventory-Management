using Item_Inventory.InventoryObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement
{
    public interface ItemManagementFramework
    {
        public void populate();
        public void itemAdd(Item item);
        public void itemRemove(Item item);
        public Item itemSearch(string name);
        public Item itemSearch(int index);
        public bool itemExist(string name);
        public void itemUpdate(Item item, string newName, int newAmount);
        public void amountAdd(Item item, int amount);
        public void amountRemove(Item item, int amount);
        public int itemSize();
        public List<Item> itemList();
    }
}
