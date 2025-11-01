using System;
using MySql.Data.MySqlClient;

class Program
{
    static string connectionString = "Server=localhost;Database=shopdb;User Id=root;Password=maheer2709;";

    static void Main()
    {
        Console.WriteLine(" Product CRUD Example \n");

        InsertProduct("Laptop", 75000.00m, 10);
        InsertProduct("Mouse", 500.00m, 50);

        Console.WriteLine("\n All Products:");
        ReadProducts();

        Console.WriteLine("\n Updating Product");
        UpdateProduct(1, "Gaming Laptop", 85000.00m, 5);

        Console.WriteLine("\n After Update:");
        ReadProducts();

        Console.WriteLine("\n Deleting Product");
        DeleteProduct(2);

        Console.WriteLine("\n After Delete:");
        ReadProducts();
    }

    //  Create
    static void InsertProduct(string name, decimal price, int quantity)
    {
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            string query = "INSERT INTO products (name, price, quantity) VALUES (@name, @price, @quantity)";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.ExecuteNonQuery();
            Console.WriteLine($"Product '{name}' added successfully!");
        }
    }

    //  Read
    static void ReadProducts()
    {
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT * FROM products";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader["id"],-5} {reader["name"],-20} ₹{reader["price"],-10} Qty: {reader["quantity"],-5}");
            }
        }
    }

    //  Update
    static void UpdateProduct(int id, string name, decimal price, int quantity)
    {
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            string query = "UPDATE products SET name=@name, price=@price, quantity=@quantity WHERE id=@id";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            Console.WriteLine(" Product updated successfully!");
        }
    }

    //  Delete
    static void DeleteProduct(int id)
    {
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            string query = "DELETE FROM products WHERE id=@id";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            Console.WriteLine(" Product deleted successfully!");
        }
    }
}
