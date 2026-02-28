using System;
using System.ComponentModel.DataAnnotations;

namespace Item_Inventory
{
    internal class Program
    {
        static List<Item> items = new List<Item>() { new Item("Hammer", 1), new Item("Nails", 10), new Item("Cigarette", 500), new Item("Plank", 20), new Item("Glue", 25), new Item("Screw", 10) };
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to NetMart Inventory Management System 200");
            Console.WriteLine("What would you like to do?");

            Console.WriteLine("Create an item (create)");
            Console.WriteLine("Delete an item (delete)");
            Console.WriteLine("Add an item (add)");
            Console.WriteLine("Remove an item (remove)");
            Console.WriteLine("Search an item(search)");

            string choice = prompt().ToLower();
            switch (choice) {
                case "create":
                    create();
                    break;
                case "delete":
                    delete();
                    break;
                case "add":
                    add();
                    break;
                case "remove":
                    remove();
                    break;
                case "search":
                    search();
                    break;
            }
        }

        static private void create()
        {
            string item;
            int amount;
            Console.WriteLine("The name of the item: ");
            item = prompt();

            Console.Write("Amount of the item: ");
            amount = int.Parse(Console.ReadLine());

            items.Add(new Item(item, amount));
        }
        static private void delete()
        {
            string itemSearch;

            Console.Write("The name of the item: ");
            itemSearch = Console.ReadLine();

            foreach(Item item in items)
            {
                if(item.getName() == itemSearch)
                {
                    items.Remove(item);
                }
            }
        }
        static private void add()
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

            item.addAmount(amount);
        }
        static private void remove()
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

            item.removeAmount(amount);
        }
        static private void search()
        {
            Item item;

            Console.Write("Find an item: ");
            item = choice();

            if (item == null)
            {
                return;
            }

            Console.WriteLine("Item: " + item.getName());
            Console.WriteLine("Amount: " + item.getAmount());
        }

        static private Item choice()
        {
            int display = 3;
            int index = 0;

            while (true)
            {
                int current = display * index;
                int next = current + display;

                int limit = next > items.Count ? items.Count : next;

                string text = "";
                text += (index == 0 ? "[Exit] " : "[Back] ");

                for(int i = current; i < limit; i++) {
                    text += $"[{items[i].getName()}] ";
                }

                if(next < items.Count)
                {
                    text += "[Next]";
                }
                Console.WriteLine(text);
                string search = prompt().ToLower();
                if (search.Equals("exit"))
                {
                    return null;
                } else if (index != 0 & search.Equals("back")) {
                    index--;
                    continue;
                } else if (next < items.Count & search.Equals("next")) {
                    index++;
                    continue;
                }

                foreach(Item item in items) {
                    if(item.getName().ToLower().Equals(search)) {
                        return item;
                    }
                }
            }
        }

        static private string prompt()
        {
            Console.Write("> ");
            return Console.ReadLine();
        }
    }
}
