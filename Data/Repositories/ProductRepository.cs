using ProductInventoryApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventoryApp.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public void AddProduct(Product product)
        {
            using (var conn = DbManager.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO Products (Name, Quantity, Price) VALUES (@Name, @Quantity, @Price)", conn);
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Product> GetAllProducts()
        {
            var products = new List<Product>();
            using (var conn = DbManager.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Products", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    products.Add(new Product
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString(),
                        Quantity = (int)reader["Quantity"],
                        Price = (decimal)reader["Price"]
                    });
                }
            }
            return products;
        }

        public List<Product> SearchProducts(string name)
        {
            var products = new List<Product>();
            using (var conn = DbManager.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Products WHERE Name LIKE @Name", conn);
                cmd.Parameters.AddWithValue("@Name", $"%{name}%");
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    products.Add(new Product
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString(),
                        Quantity = (int)reader["Quantity"],
                        Price = (decimal)reader["Price"]
                    });
                }
            }
            return products;
        }
    }
}
