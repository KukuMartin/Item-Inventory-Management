using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_Inventory.InventoryObject
{
    public class Category
    {
        public Guid id { get; }
        public int name { get; set; }

        public Category(Guid id, int name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
