using Item_Inventory.InventoryObject;
using Item_Inventory.InventoryManagement;
using InventoryManagement;
using InventoryService;

namespace Item_Inventory.InventoryService
{
    public class ItemService
    {
        ItemManagement manager = new ItemManagement(new ItemDatabaseManagement());

        public bool create(Item item)
        {
            if (manager.itemExist(item.name))
            {
                return false;
            } 
            else if (item.amount < 0)
            {
                return false;
            }

            manager.itemAdd(item);
            return true;
        }

        public bool delete(Item item)
        {   
            if (!manager.itemExist(item.name))
            {
                return false;
            }

            manager.itemRemove(item);
            return true;
        }
        public bool add(Item item, int amount)
        {
            if (!manager.itemExist(item.name))
            {
                return false;
            }
            else if (amount <= 0)
            {
                return false;
            }

            Item add = manager.itemSearch(item.name);
            manager.amountAdd(add, amount);
            return true;
        }

        public bool remove(Item item, int amount)
        {
            if (!manager.itemExist(item.name))
            {
                return false;
            }
            else if (amount <= 0 || amount > item.amount)
            {
                return false;
            }

            Item remove = manager.itemSearch(item.name);
            manager.amountRemove(remove, amount);
            return true;
        }

        public Item search(int index)
        {
            if (index < 0 || index >= manager.itemSize())
            {
                return null;
            }

            return manager.itemSearch(index);
        }
        public Item search(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }

            return manager.itemSearch(name);
        }
        public int size()
        {
            return manager.itemSize();
        }


        public bool exist(string name)
        {
            return manager.itemExist(name);
        }
    }
}
