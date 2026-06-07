using System;

namespace Item_Inventory.InventoryObject
{
	public class Item
	{
        public Guid id { get; }
        public Guid categoryId { get; set; }
        public string name { get; set; }
        public int amount { get; set; }

        public Item(Guid id, Guid categoryId, string name, int amount)
		{
			this.id = id;
			this.categoryId = categoryId;
			this.name = name;
			this.amount = amount;
		}
	}
}


