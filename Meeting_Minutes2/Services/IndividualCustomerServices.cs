using Meeting_Minutes2.Interfaces;
using Meeting_Minutes2.Models;
using System.Data.SqlClient;

namespace Meeting_Minutes2.Services
{
    public class IndividualCustomerServices : IIndividualCustomerServices
    {
        private readonly string _connectionString;

        public IndividualCustomerServices(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<IndividualCustomer> GetIndividualCustomerList()
        {
            var indiCustomers = new List<IndividualCustomer>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT Id, Name FROM Individual_Customer_Tbl", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        indiCustomers.Add(new IndividualCustomer
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        });
                    }
                }
            }

            return indiCustomers;
        }

        public IndividualCustomer GetIndividualCustomerById(int? id)
        {
            IndividualCustomer indiCustomer = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT Id, Name FROM Individual_Customer_Tbl WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        indiCustomer = new IndividualCustomer
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        };
                    }
                }
            }

            return indiCustomer;
        }

        public void CreateIndividualCustomer(IndividualCustomer indiCustomer)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Individual_Customer_Tbl (Name) VALUES (@Name)", connection);
                command.Parameters.AddWithValue("@Name", indiCustomer.Name);

                command.ExecuteNonQuery();
            }
        }

        public void UpdateIndividualCustomer(IndividualCustomer indiCustomer)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("UPDATE Individual_Customer_Tbl SET Name = @Name WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Name", indiCustomer.Name);
                command.Parameters.AddWithValue("@Id", indiCustomer.Id);

                command.ExecuteNonQuery();
            }

        }

        public void DeleteIndividualCustomer(int? id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM Individual_Customer_Tbl WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
        }
    }
}
