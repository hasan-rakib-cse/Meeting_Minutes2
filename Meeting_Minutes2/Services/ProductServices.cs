using Meeting_Minutes2.Interfaces;
using Meeting_Minutes2.Models;
using System.Data.SqlClient;

namespace Meeting_Minutes2.Services
{
    public class ProductServices : IProductServices
    {
        private readonly string _connectionString;

        public ProductServices(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<ProductService> GetProductServiceList()
        {
            var proService = new List<ProductService>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT Id, Name, Unit FROM Products_Service_Tbl", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        proService.Add(new ProductService
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Unit = reader.GetString(2)
                        });
                    }
                }
            }

            return proService;
        }

        public ProductService GetProductServiceById(int? id)
        {
            ProductService proService = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT Id, Name, Unit FROM Products_Service_Tbl WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        proService = new ProductService
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Unit = reader.GetString(2)
                        };
                    }
                }
            }

            return proService;
        }

        public void CreateProductService(ProductService proService)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Products_Service_Tbl (Name, Unit) VALUES (@Name, @Unit)", connection);
                command.Parameters.AddWithValue("@Name", proService.Name);
                command.Parameters.AddWithValue("@Unit", proService.Unit);

                command.ExecuteNonQuery();
            }
        }

        public void UpdateProductService(ProductService proService)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("UPDATE Products_Service_Tbl SET Name = @Name, Unit = @Unit WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Name", proService.Name);
                command.Parameters.AddWithValue("@Unit", proService.Unit);
                command.Parameters.AddWithValue("@Id", proService.Id);

                command.ExecuteNonQuery();
            }
        }

        public void DeleteProductService(int? id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM Products_Service_Tbl WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
        }

    }
}
