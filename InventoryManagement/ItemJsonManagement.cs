using InventoryManagement;
using Item_Inventory.InventoryObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace InventoryService
{
    public class ItemJsonManagement : ItemManagementFramework
    {
        private List<Item> items = new List<Item>();

        private string _jsonFileName;

        public ItemJsonManagement()
        {
            _jsonFileName = $"{AppDomain.CurrentDomain.BaseDirectory}/Items.json";
            Console.WriteLine(_jsonFileName);

            populate();
        }

        public void populate()
        {
            this.ReadJson();

            if(this.itemSize() != 0)
            {
                return;
            }

            this.itemAdd(new Item("Hammer", 1));
            this.itemAdd(new Item("Nails", 10));
            this.itemAdd(new Item("Cigarette", 500));
            this.itemAdd(new Item("Plank", 20));
            this.itemAdd(new Item("Glue", 25));
            this.itemAdd(new Item("Screw", 10));

            this.WriteJson();
        }

        private void WriteJson()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(items, options);

            File.WriteAllText(_jsonFileName, json);
        }

        private void ReadJson()
        {
            using (var jsonFileReader = File.OpenText(_jsonFileName))
            {
                items = JsonSerializer.Deserialize<List<Item>>
                    (jsonFileReader.ReadToEnd(), new JsonSerializerOptions
                    { PropertyNameCaseInsensitive = true })
                    .ToList();
            }
        }

        public void itemAdd(Item item)
        {
            items.Add(item);
            this.WriteJson();
        }
        public void itemRemove(Item item)
        {
            items.Remove(item);
            this.WriteJson();
        }

        public Item itemSearch(string name)
        {
            return items.FirstOrDefault(item => item.name.ToLower() == name.ToLower());
        }

        public Item itemSearch(int index)
        {
            return items[index];

        }

        public bool itemExist(string name)
        {
            Item item = items.FirstOrDefault(item => item.name.ToLower() == name.ToLower());
            return item != null;
        }

        public void itemUpdate(Item item, string newName, int newAmount)
        {
            item.name = newName;
            item.amount = newAmount;
            this.WriteJson();
        }

        public void amountAdd(Item item, int amount)
        {
            item.amount += amount;
            this.WriteJson();
        }

        public void amountRemove(Item item, int amount)
        {
            item.amount -= amount;
            this.WriteJson();
        }
        public int itemSize()
        {
            return items.Count;
        }
        public List<Item> itemList()
        {
            return items;
        }
    }
}
