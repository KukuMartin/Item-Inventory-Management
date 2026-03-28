using Item_Inventory.InventoryObject;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement
{
    public class ItemDatabaseManagement : ItemManagementFramework
    {
        private string SqlConnection
        = "Data Source =localhost\\SQLEXPRESS; Initial Catalog = ItemInventory; Integrated Security = True; TrustServerCertificate=True;";

        private SqlConnection sqlConnection;

        public ItemDatabaseManagement()
        {
            sqlConnection = new SqlConnection(SqlConnection);
            this.populate();
        }

        public void populate()
        {
            if (this.itemSize() != 0)
            {
                return;
            }

            this.itemAdd(new Item("Hammer", 1));
            this.itemAdd(new Item("Nails", 10));
            this.itemAdd(new Item("Cigarette", 500));
            this.itemAdd(new Item("Plank", 20));
            this.itemAdd(new Item("Glue", 25));
            this.itemAdd(new Item("Screw", 10));
        }

        public void amountAdd(Item item, int amount)
        {
            throw new NotImplementedException();
        }

        public void amountRemove(Item item, int amount)
        {
            throw new NotImplementedException();
        }

        public void itemAdd(Item item)
        {
            var insertStatement = "INSERT INTO Accounts VALUES (@Name, @Amount)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@Name", item.name);
            insertCommand.Parameters.AddWithValue("@Amount", item.amount);
            sqlConnection.Open();

            insertCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public bool itemExist(string name)
        {
            throw new NotImplementedException();
        }

        public List<Item> itemList()
        {
            string selectStatement = "SELECT Name, Amount FROM Item";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();

            SqlDataReader reader = selectCommand.ExecuteReader();

            var items = new List<Item>();

            while (reader.Read())
            {
                //deserialize
                String name = reader["Name"].ToString(); ;
                int amount = (int)reader["Amount"];
                Item item = new Item(name, amount);

                items.Add(item);
            }

            sqlConnection.Close();
            return items;
        }

        public void itemRemove(Item item)
        {
            throw new NotImplementedException();
        }

        public Item itemSearch(string name)
        {
            throw new NotImplementedException();
        }

        public Item itemSearch(int index)
        {
            throw new NotImplementedException();
        }

        public int itemSize()
        {
            throw new NotImplementedException();
        }

        public void itemUpdate(Item item, string newName, int newAmount)
        {
            throw new NotImplementedException();
        }
    }
}
