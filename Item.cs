using System;

namespace Item_Inventory {
	public class Item
	{
	    private string name;
        private int amount;
		
		public Item(string name, int amount)
		{
			this.name = name;
			this.amount = amount;
		}

		public string getName()
		{
			return name;
		}

		public int getAmount()
		{
			return amount;
		}

		public string addAmount(int amount)
		{
			this.amount += amount;
            return $"Succesfully added {amount} item";
        }

		public string removeAmount(int amount)
		{
			if (amount > this.amount)
			{
				this.amount -= amount;
				return $"Failed to remove {amount} item";
			}
            return $"Succesfully remove {amount} item";
        }
	}
}


