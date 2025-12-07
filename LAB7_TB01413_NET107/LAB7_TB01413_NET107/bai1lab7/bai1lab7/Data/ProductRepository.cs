using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using InventoryManagement.Models;
using Microsoft.Extensions.Configuration;

namespace InventoryManagement.Data
{
    public class ProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public IEnumerable<Product> GetAll()
        {
            var products = new List<Product>();

            const string query = @"SELECT * FROM Products ORDER BY Id DESC";

            using (var conn = GetConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(MapProduct(reader));
                    }
                }
            }

            return products;
        }
        public Product GetById(int id)
        {
            Product product = null;

            const string query = @"SELECT * FROM Products WHERE Id = @Id";

            using (var conn = GetConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        product = MapProduct(reader);
                    }
                }
            }

            return product;
        }

        public void Create(Product product)
        {
            const string query = @"
                INSERT INTO Products 
                (Name, Category, Color, UnitPrice, AvailableQuantity, CreatedDate)
                VALUES 
                (@Name, @Category, @Color, @UnitPrice, @AvailableQuantity, @CreatedDate)
            ";

            using (var conn = GetConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = product.Name;
                cmd.Parameters.Add("@Category", SqlDbType.NVarChar).Value = product.Category;
                cmd.Parameters.Add("@Color", SqlDbType.NVarChar).Value = (object?)product.Color ?? DBNull.Value;
                cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = product.UnitPrice;
                cmd.Parameters.Add("@AvailableQuantity", SqlDbType.Int).Value = product.AvailableQuantity;
                cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = product.CreatedDate;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Product product)
        {
            const string query = @"
                UPDATE Products
                SET 
                    Name = @Name,
                    Category = @Category,
                    Color = @Color,
                    UnitPrice = @UnitPrice,
                    AvailableQuantity = @AvailableQuantity,
                    CreatedDate = @CreatedDate
                WHERE Id = @Id
            ";

            using (var conn = GetConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = product.Id;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = product.Name;
                cmd.Parameters.Add("@Category", SqlDbType.NVarChar).Value = product.Category;
                cmd.Parameters.Add("@Color", SqlDbType.NVarChar).Value = (object?)product.Color ?? DBNull.Value;
                cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = product.UnitPrice;
                cmd.Parameters.Add("@AvailableQuantity", SqlDbType.Int).Value = product.AvailableQuantity;
                cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = product.CreatedDate;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            const string query = "DELETE FROM Products WHERE Id = @Id";

            using (var conn = GetConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }


        private Product MapProduct(IDataRecord record)
        {
            return new Product
            {
                Id = Convert.ToInt32(record["Id"]),
                Name = Convert.ToString(record["Name"]),
                Category = Convert.ToString(record["Category"]),
                Color = record["Color"] == DBNull.Value ? null : Convert.ToString(record["Color"]),
                UnitPrice = Convert.ToDecimal(record["UnitPrice"]),
                AvailableQuantity = Convert.ToInt32(record["AvailableQuantity"]),
                CreatedDate = Convert.ToDateTime(record["CreatedDate"])
            };
        }
    }
}
