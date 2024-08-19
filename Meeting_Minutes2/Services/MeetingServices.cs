using Meeting_Minutes2.Interfaces;
using Meeting_Minutes2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Meeting_Minutes2.Services
{
    public class MeetingServices : IMeetingServices
    {
        private readonly string _connectionString;

        public MeetingServices(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<ProductService> GetProduct()
        {
            var products = new List<ProductService>();
            return products;
        }
    }
}
