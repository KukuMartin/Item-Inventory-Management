using System;

namespace Item_Inventory
{
    internal class Program
    {
        List<Item> items = new List<Item>() { new Item("Hammer", 1), new Item("Nails", 10), new Item("Cigarette", 500), new Item("Plank", 20), new Item("Glue", 25), new Item("Screw", 10) };
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to NetMart Inventory Management System 200");
            Console.WriteLine("What would you like to do?");

            Console.WriteLine("Create an item (create)");
            Console.WriteLine("Delete an item (delete)");
            Console.WriteLine("Add an item (add)");
            Console.WriteLine("Remove an item (remove)");
            Console.WriteLine("Search an item(search)");

        }

        private void create()
        {
            string item;
            int amount;
            Console.Write("The name of the item: ");
            item = Console.ReadLine();

            Console.Write("Amount of the item: ");
            amount = int.Parse(Console.ReadLine());

            items.Add(new Item(item, amount));
        }
        private void delete()
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
        private void add()
        {

        }
        private void remove()
        {

        }
        private void search()
        {

        }
    }
}
