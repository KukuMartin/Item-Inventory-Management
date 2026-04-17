using Item_Inventory.InventoryObject;
using Item_Inventory.InventoryService;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Item_Inventory
{
    internal class Program
    {
        private static GuiConsole gui;
        static void Main(string[] args)
        {
            Boolean reset = true;
            gui = new GuiConsole();

            while(reset)
            {
                Console.WriteLine("\nWelcome to NetMart Inventory Management System 200");
                Console.WriteLine("What would you like to do?");

                Console.WriteLine("Create an item  (create)");
                Console.WriteLine("Delete an item  (delete)");
                Console.WriteLine("Add an item     (add)");
                Console.WriteLine("Remove an item  (remove)");
                Console.WriteLine("Display an item (display)");

                string choice = gui.prompt().ToLower();
                switch (choice)
                {
                    case "create":
                        gui.create();
                        break;
                    case "delete":
                        gui.delete();
                        break;
                    case "add":
                        gui.add();
                        break;
                    case "remove":
                        gui.remove();
                        break;
                    case "display":
                        gui.display();
                        break;
                    default:
                        gui.announce("Invalid input");
                        continue;
                }
                reset = Program.reset();
            }
        }

        private static bool reset()
        {
            string answer;

            while (true)
            {
                Console.WriteLine("\nContinue? ");

                answer = gui.prompt().ToLower();
                if (answer.ToLower() == "yes")
                {
                    Console.WriteLine();
                    return true;
                }
                if (answer.ToLower() == "no")
                {
                    Console.WriteLine();
                    return false;
                }
                else
                {
                    gui.announce("Invalid input");
                    continue;
                }
            }
        }

        
    }
}
