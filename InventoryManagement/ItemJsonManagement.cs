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
    internal class ItemJsonManagement : ItemManagementFramework
    {
        private List<Item> items = new List<Item>();

        private string _jsonFileName;

        public ItemJsonManagement()
        {
            _jsonFileName = $"{AppDomain.CurrentDomain.BaseDirectory}/Accounts.json";

            populate();
        }

        public void populate()
        {
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
            using (var outputStream = File.OpenWrite(_jsonFileName))
            {
                JsonSerializer.Serialize<List<Item>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    { SkipValidation = true, Indented = true })
                    , items);
            }
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
            this.ReadJson();
            return items.FirstOrDefault(item => item.name == name);
        }
        public Item itemSearch(int index)
        {
            this.ReadJson();
            return items[index];
        }

        public bool itemExist(string name)
        {
            this.ReadJson();
            Item item = items.FirstOrDefault(item => item.name == name);
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
            this.ReadJson();
            return items.Count;
        }
        public List<Item> itemList()
        {
            this.ReadJson();
            return items;
        }
    }
}
