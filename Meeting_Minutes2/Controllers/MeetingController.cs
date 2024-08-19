using Meeting_Minutes2.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Meeting_Minutes2.Controllers
{
    public class MeetingController : Controller
    {
        private readonly IMeetingServices _services;

        public MeetingController(IMeetingServices services)
        {
            _services = services;
        }

        public IActionResult MeetingInvoice()
        {
            var prod = _services.GetProduct();
            return View();
        }
    }
}
