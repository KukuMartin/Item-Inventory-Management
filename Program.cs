using System;
using System.ComponentModel.DataAnnotations;
using InventoryService;

namespace Item_Inventory
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            InventoryService service = new InventoryService();

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
                    service.create();
                    break;
                case "delete":
                    service.delete();
                    break;
                case "add":
                    service.add();
                    break;
                case "remove":
                    service.remove();
                    break;
                case "search":
                    service.search();
                    break;
            }
        }
    }
}
