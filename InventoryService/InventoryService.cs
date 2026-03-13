using Item_Inventory.InventoryObject;

namespace Item_Inventory.InventoryService
{
    public class InventoryService
    {
        ItemManagement manager = new ItemManagement();


        InventoryService()
        {
            manager.itemAdd(new Item("Hammer", 1));
            manager.itemAdd(new Item("Nails", 10));
            manager.itemAdd(new Item("Cigarette", 500));
            manager.itemAdd(new Item("Plank", 20));
            manager.itemAdd(new Item("Glue", 25));
            manager.itemAdd(new Item("Screw", 10));
        }

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

        private Item choice()
        {
            int display = 3;
            int index = 0;

            while (true)
            {
                int current = display * index;
                int next = current + display;

                int limit = next > manager.itemSize() ? manager.itemSize() : next;

                string text = "";
                text += (index == 0 ? "[Exit] " : "[Back] ");

                for (int i = current; i < limit; i++)
                {
                    text += $"[{manager.itemSearch(i)}] ";
                }

                if (next < manager.itemSize())
                {
                    text += "[Next]";
                }
                Console.WriteLine(text);
                string search = prompt().ToLower();
                if (search.Equals("exit"))
                {
                    return null;
                }
                else if (index != 0 & search.Equals("back"))
                {
                    index--;
                    continue;
                }
                else if (next < manager.itemSize() & search.Equals("next"))
                {
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

        private string prompt()
        {
            Console.Write("> ");
            return Console.ReadLine();
        }
    }
}
