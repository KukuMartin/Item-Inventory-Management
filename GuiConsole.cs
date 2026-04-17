    using Item_Inventory.InventoryObject;
using Item_Inventory.InventoryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_Inventory
{
    public class GuiConsole
    {
        private ItemService service;

        public GuiConsole()
        {
            service = new ItemService();
        }

        public void create()
        {
            string name;
            int amount;

            Console.WriteLine("\nCREATE: ");
            Console.WriteLine("The name of the item: ");
            name = this.prompt();

            if (service.exist(name))
            {
                this.announce("Item name already exists");
                return;
            }

            Console.Write("Amount of the item: ");
            amount = int.Parse(Console.ReadLine());

            if (amount <= 0)
            {
                this.announce("Invalid item amount input");
                return;
            }

            this.announce("Item created");
            service.create(new Item(name, amount));
        }

        public void delete()
        {
            Item item;

            Console.WriteLine("\nDELETE: ");
            Console.Write("The name of the item: ");
            item = this.choice();

            if (item == null)
            {
                return;
            }

            this.announce("Item deleted");
            service.delete(item);
        }

        public void add()
        {
            Item item;
            int amount;

            Console.WriteLine("\nADD");
            Console.Write("Find an item: ");
            item = choice();

            if (item == null)
            {
                return;
            }


            Console.WriteLine("How much to add: ");
            amount = int.Parse(prompt());

            if (amount <= 0)
            {
                this.announce("Invalid input");
                return;
            }

            this.announce("Amount added");
            service.add(item, amount);
        }

        public void remove()
        {
            Item item;
            int amount;

            Console.WriteLine("\nREMOVE");
            Console.Write("Find an item: ");
            item = choice();

            if (item == null)
            {
                return;
            }


            Console.WriteLine("How much to remove: ");
            amount = int.Parse(prompt());

            if (amount <= 0 || amount > item.amount)
            {
                this.announce("Invalid input");
                return;
            }

            this.announce("Amount remove");
            service.remove(item, amount);
        }
        public void display()
        {
            Item item;

            Console.WriteLine("\nDISPLAY");
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
                int size = service.size();

                if (size == 0)
                {
                    this.announce("No items available");
                    return null;
                }

                int current = display * index;
                int next = current + display;
                int limit = next > size ? size : next;

                string text = "";
                text += (index == 0 ? "" : "[Back] ");

                for (int i = current; i < limit; i++)
                {
                    text += $"[{service.search(i).name}] ";
                }

                if (next < size)
                {
                    text += "[Next]";
                }

                Console.WriteLine(text);
                string search = prompt().ToLower();

                if (index != 0 && search.Equals("back"))
                {
                    index--;
                    continue;
                }
                else if (next < size && search.Equals("next"))
                {
                    index++;
                    continue;
                }

                for (int i = current; i < limit; i++)
                {
                    Item item = service.search(i);
                    if (item.name.ToLower().Equals(search))
                    {
                        return item;
                    }
                }

                this.announce("Invalid input"); 
            }
        }

        public string prompt()
        {
            Console.Write("> ");
            return Console.ReadLine();
        }

        public void announce(string error)
        {
            Console.Write("\n* " + error + " *\n");
        }
    }
}
