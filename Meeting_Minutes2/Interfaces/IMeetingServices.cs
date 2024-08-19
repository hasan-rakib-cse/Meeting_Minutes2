using Meeting_Minutes2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Meeting_Minutes2.Interfaces
{
    public interface IMeetingServices
    {
        //public IActionResult MeetingInvoice();

        public List<ProductService> GetProduct();
    }
}
