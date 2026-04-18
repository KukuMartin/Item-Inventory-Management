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
        private string connectionString
        = "Data Source =localhost\\SQLEXPRESS; Initial Catalog = ItemInventory; Integrated Security = True; TrustServerCertificate=True;";

        private SqlConnection sqlConnection;

        public ItemDatabaseManagement()
        {
            sqlConnection = new SqlConnection(connectionString);
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
            int newAmount = item.amount + amount;
            var addStatement = "UPDATE Items SET Amount = @Amount WHERE Name = @Name";

            SqlCommand addCommand = new SqlCommand(addStatement, sqlConnection);
            addCommand.Parameters.AddWithValue("@Name", item.name);
            addCommand.Parameters.AddWithValue("@Amount", newAmount);
            sqlConnection.Open();

            addCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public void amountRemove(Item item, int amount)
        {
            int newAmount = item.amount - amount;

            if(newAmount < 0)
            {
                return;
            }

            var addStatement = "UPDATE Items SET Amount = @Amount WHERE Name = @Name";

            SqlCommand addCommand = new SqlCommand(addStatement, sqlConnection);
            addCommand.Parameters.AddWithValue("@Name", item.name);
            addCommand.Parameters.AddWithValue("@Amount", newAmount);
            sqlConnection.Open();

            addCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public void itemAdd(Item item)
        {
            var insertStatement = "INSERT INTO Items VALUES (@Name, @Amount)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);
            insertCommand.Parameters.AddWithValue("@Name", item.name);
            insertCommand.Parameters.AddWithValue("@Amount", item.amount);
            sqlConnection.Open();

            insertCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public bool itemExist(string name)
        {
            var searchStatement = "SELECT 1 FROM Items WHERE Name = @Name";

            SqlCommand searchCommand = new SqlCommand(searchStatement, sqlConnection);
            searchCommand.Parameters.AddWithValue("@Name", name);
            sqlConnection.Open();

            SqlDataReader reader = searchCommand.ExecuteReader();
            bool itemExist = reader.Read();

            sqlConnection.Close();
            return itemExist;
        }

        public List<Item> itemList()
        {
            var selectStatement = "SELECT Name, Amount FROM Items";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();

            SqlDataReader reader = selectCommand.ExecuteReader();

            var items = new List<Item>();

            while (reader.Read())
            {
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
            var deleteStatement = "DELETE FROM Items WHERE Name = @Name";

            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);
            deleteCommand.Parameters.AddWithValue("@Name", item.name);
            sqlConnection.Open();

            deleteCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public Item itemSearch(string name)
        {
            var searchStatement = "SELECT Name, Amount FROM Items WHERE Name = @Name";

            SqlCommand searchCommand = new SqlCommand(searchStatement, sqlConnection);
            searchCommand.Parameters.AddWithValue("@Name", name);
            sqlConnection.Open();

            SqlDataReader reader = searchCommand.ExecuteReader();
            reader.Read();

            Item item = new Item(reader["Name"].ToString(), (int)reader["Amount"]);

            sqlConnection.Close();
            return item;
        }

        public Item itemSearch(int index)
        {
            var searchStatement = "SELECT Name, Amount FROM Items WHERE ID = @Index";

            SqlCommand searchCommand = new SqlCommand(searchStatement, sqlConnection);
            searchCommand.Parameters.AddWithValue("@Index", index + 1);
            sqlConnection.Open();

            SqlDataReader reader = searchCommand.ExecuteReader();
            reader.Read();
            Item item = new Item(reader["Name"].ToString(), (int)reader["Amount"]);

            sqlConnection.Close();
            return item;
        }

        public int itemSize()
        {
            int size;
            var sizeStatement = "SELECT COUNT(ID) AS Size FROM Items";

            SqlCommand sizeCommand = new SqlCommand(sizeStatement, sqlConnection);
            sqlConnection.Open();

            SqlDataReader reader = sizeCommand.ExecuteReader();
            reader.Read();

            size = (int)reader["Size"];

            sqlConnection.Close();
            return size;
        }

        public void itemUpdate(Item item, string newName, int newAmount)
        {
            var updateStatement = "UPDATE Items SET Name = @NewName, Amount = @NewAmount WHERE Name = @Name AND Amount = @Amount";

            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
            updateCommand.Parameters.AddWithValue("@Name", item.name);
            updateCommand.Parameters.AddWithValue("@Amount", item.amount);
            updateCommand.Parameters.AddWithValue("@NewName", newName);
            updateCommand.Parameters.AddWithValue("@NewAmount", newAmount);
            sqlConnection.Open();

            updateCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }
    }
}
