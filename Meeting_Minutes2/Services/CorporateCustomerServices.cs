using Meeting_Minutes2.Interfaces;
using Meeting_Minutes2.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Meeting_Minutes2.Services
{
    public class CorporateCustomerServices : ICorporateCustomerServices
    {
        private readonly string _connectionString;

        public CorporateCustomerServices(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<CorporateCustomer> GetCorporateCustomerList()
        {
            var corporateCustomers = new List<CorporateCustomer>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT Id, Name FROM Corporate_Customer_Tbl", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        corporateCustomers.Add(new CorporateCustomer
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        });
                    }
                }
            }

            return corporateCustomers;
        }

        public CorporateCustomer GetCorporateCustomerById(int? id)
        {
            CorporateCustomer corpoCustomer = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT Id, Name FROM Corporate_Customer_Tbl WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        corpoCustomer = new CorporateCustomer
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        };
                    }
                }
            }

            return corpoCustomer;
        }

        public void CreateCorporateCustomer(CorporateCustomer corpoCustomer)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Corporate_Customer_Tbl (Name) VALUES (@Name)", connection);
                command.Parameters.AddWithValue("@Name", corpoCustomer.Name);

                command.ExecuteNonQuery();
            }
        }

        public void UpdateCorporateCustomer(CorporateCustomer corpoCustomer)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("UPDATE Corporate_Customer_Tbl SET Name = @Name WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Name", corpoCustomer.Name);
                command.Parameters.AddWithValue("@Id", corpoCustomer.Id);

                command.ExecuteNonQuery();
            }

        }

        public void DeleteCorporateCustomer(int? id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM Corporate_Customer_Tbl WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
        }

    }
}
