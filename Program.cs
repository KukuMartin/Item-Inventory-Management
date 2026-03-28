using System;
using System.ComponentModel.DataAnnotations;
using Item_Inventory.InventoryService;

namespace Item_Inventory
{
    internal class Program
    {
        static ItemService service;
        static void Main(string[] args)
        {
            Boolean reset;
            service = new ItemService();
            do
            {
                Console.WriteLine("Welcome to NetMart Inventory Management System 200");
                Console.WriteLine("What would you like to do?");

                Console.WriteLine("Create an item (create)");
                Console.WriteLine("Delete an item (delete)");
                Console.WriteLine("Add an item (add)");
                Console.WriteLine("Remove an item (remove)");
                Console.WriteLine("Search an item(search)");

                string choice = service.prompt().ToLower();
                switch (choice)
                {
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
                reset = Program.reset();
            } while (reset);
        }

        static bool reset()
        {
            string answer;
            Console.WriteLine("\nContinue? ");

            answer = service.prompt().ToLower();
            if(answer == "yes") {
                Console.WriteLine();//new line for pretties
                return true;
            } else {
                return false;
            }
        }
    }
}
