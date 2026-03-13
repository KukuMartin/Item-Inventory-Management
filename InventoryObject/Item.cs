using System;

namespace Item_Inventory.InventoryObject
{
	public class Item
	{
		public string name { get; set; }
        public int amount { get; set; }

        public Item(string name, int amount)
		{
			this.name = name;
			this.amount = amount;
		}
	}
}


