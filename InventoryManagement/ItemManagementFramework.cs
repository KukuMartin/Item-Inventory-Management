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
        public List<Category> getAllCategory();
        public Category getCategory(Guid categoryId);
        public List<Item> getAllItem(Guid categoryId);
        public Item getItem(Guid itemId);
        public void addCategory(Category category);
        public void addItem(Item item);
        public void removeCategory(Guid categoryId);
        public void removeItem(Guid itemId);
        public bool CategoryExist(Guid categoryId);
        public bool ItemExist(Guid itemId);
    }
}
