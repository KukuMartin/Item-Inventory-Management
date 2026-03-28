using Item_Inventory.InventoryObject;
using Item_Inventory.InventoryManagement;
using InventoryManagement;
using InventoryService;

namespace Item_Inventory.InventoryService
{
    public class ItemService
    {
        ItemManagement manager = new ItemManagement(new ItemMemoryManagement());

        public void create()
        {
            Item item;
            string name;
            int amount;
            Console.WriteLine("The name of the item: ");
            name = prompt();

            Console.Write("Amount of the item: ");
            amount = int.Parse(Console.ReadLine());

            item = new Item(name, amount);

            if(manager.itemExist(name))
            {
                Console.WriteLine("Item already exists");
                return;
            }

            manager.itemAdd(item);
        }

        public void delete()
        {
            Item item;
            string itemSearch;

            Console.Write("The name of the item: ");
            itemSearch = Console.ReadLine();

            item = manager.itemSearch(itemSearch);

            if (item != null)
            {
                manager.itemRemove(item);
            }
        }
        public void add()
        {
            Item item;
            int amount;

            Console.Write("Find an item: ");
            item = choice();

            if (item == null)
            {
                return;
            }

            Console.WriteLine("How much to add: ");
            amount = int.Parse(prompt());

            manager.amountAdd(item, amount);
        }
        public void remove()
        {
            Item item;
            int amount;

            Console.Write("Find an item: ");
            item = choice();

            if (item == null)
            {
                return;
            }

            Console.WriteLine("How much to remove: ");
            amount = int.Parse(prompt());

            if(item.amount >= amount)
            {
                manager.amountRemove(item, amount);
            }
        }
        public void search()
        {
            Item item;

            Console.Write("Find an item: ");
            item = choice();

            if (item == null)
            {
                return;
            }

            Console.WriteLine("Item: " + item.name);
            Console.WriteLine("Amount: " + item.amount);
        }

        public Item choice()    
        {
            int display = 3;
            int index = 0;

            while (true)
            {
                int size = manager.itemSize();
                int current = display * index;
                int next = current + display;

                int limit = next > size ? size : next;

                string text = "";
                text += (index == 0 ? "[Exit] " : "[Back] ");

                for (int i = current; i < limit; i++)
                {
                    text += $"[{manager.itemSearch(i).name}] ";
                }

                if (next < size)
                {
                    text += "[Next]";
                }
                Console.WriteLine(text);
                string search = prompt().ToLower();

                if (search.Equals("exit")) {
                    return null;
                } else if (index != 0 & search.Equals("back")) {
                    index--;
                    continue;
                } else if (next < size & search.Equals("next")) {
                    index++;
                    continue;
                }

                foreach (Item item in manager.itemList())
                {
                    if (item.name.ToLower().Equals(search))
                    {
                        return item;
                    }
                }
            }
        }

        public string prompt()
        {
            Console.Write("> ");
            return Console.ReadLine();
        }
    }
}
