using Item_Inventory.InventoryObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement
{
    public class ItemManagement
    {
        ItemManagementFramework framework;

        public ItemManagement(ItemManagementFramework framework)
        {
            this.framework = framework;
        }

        public void itemAdd(Item item)
        {
            framework.itemAdd(item);
        }
        public void itemRemove(Item item)
        {
            framework.itemRemove(item);
        }
        public Item itemSearch(string name)
        {
            return framework.itemSearch(name);
        }
        public Item itemSearch(int index)
        {
            return framework.itemSearch(index);
        }
        public bool itemExist(string name)
        {
            return framework.itemExist(name);
        }
        public void itemUpdate(Item item, string newName, int newAmount)
        {
            framework.itemUpdate(item, newName, newAmount);
        }
        public void amountAdd(Item item, int amount)
        {
            framework.amountAdd(item, amount);
        }
        public void amountRemove(Item item, int amount)
        {
            framework.amountRemove(item, amount);
        }
        public int itemSize()
        {
            return framework.itemSize();
        }
        public List<Item> itemList()
        {
            return framework.itemList();
        }
    }
}
