using Item_Inventory.InventoryObject;
using Item_Inventory.InventoryManagement;
using InventoryManagement;
using InventoryService;

namespace Item_Inventory.InventoryService
{
    public class ItemService
    {
        ItemManagement manager = new ItemManagement(new ItemJsonManagement());

        public void create(Item item)
        {
            if (manager.itemExist(item.name))
            {
                return;
            } 
            else if (item.amount < 0)
            {
                return;
            }

            manager.itemAdd(item);
        }

        public void delete(Item item)
        {   
            if (!manager.itemExist(item.name))
            {
                return;
            }

            manager.itemRemove(item);
        }
        public void add(Item item, int amount)
        {
            if (!manager.itemExist(item.name))
            {
                return;
            }
            else if (amount <= 0)
            {
                return;
            }

            Item add = manager.itemSearch(item.name);
            manager.amountAdd(add, amount);
        }

        public void remove(Item item, int amount)
        {
            if (!manager.itemExist(item.name))
            {
                return;
            }
            else if (amount <= 0 || amount > item.amount)
            {
                return;
            }

            Item remove = manager.itemSearch(item.name);
            manager.amountRemove(remove, amount);
        }

        public Item search(int index)
        {
            if (index < 0 || index >= manager.itemSize())
            {
                return null;
            }

            return manager.itemSearch(index);
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
