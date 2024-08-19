using Meeting_Minutes2.Interfaces;
using Meeting_Minutes2.Models;
using Meeting_Minutes2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Meeting_Minutes2.Controllers
{
    public class CorporateCustomerController : Controller
    {
        private readonly ICorporateCustomerServices _services;

        public CorporateCustomerController(ICorporateCustomerServices services)
        {
            _services = services;
        }

        public IActionResult Index()
        {
            var corpoCustomers = _services.GetCorporateCustomerList();
            return View(corpoCustomers);
        }

        public IActionResult Details(int id)
        {
            CorporateCustomer corpoCustomer = _services.GetCorporateCustomerById(id);
            if (corpoCustomer == null)
            {
                return NotFound();
            }
            return View(corpoCustomer);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CorporateCustomer corpoCustomer)
        {
            if (ModelState.IsValid)
            {
                _services.CreateCorporateCustomer(corpoCustomer);
                return RedirectToAction(nameof(Index));
            }
            return View(corpoCustomer);
        }

        public IActionResult Edit(int id)
        {
            var corpoCustomer = _services.GetCorporateCustomerById(id);
            if (corpoCustomer == null)
            {
                return NotFound();
            }
            return View(corpoCustomer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CorporateCustomer corpoCustomer)
        {
            if (id != corpoCustomer.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _services.UpdateCorporateCustomer(corpoCustomer);
                return RedirectToAction(nameof(Index));
            }
            return View(corpoCustomer);
        }

        public IActionResult Delete(int id)
        {
            var corpoCustomer = _services.GetCorporateCustomerById(id);
            if (corpoCustomer == null)
            {
                return NotFound();
            }
            return View(corpoCustomer);

            //CorporateCustomer corpoCustomer = _services.GetCorporateCustomerById(id);
            //return View(corpoCustomer);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(CorporateCustomer corpoCustomer)
        {
            //_services.DeleteCorporateCustomer(id);
            //return RedirectToAction(nameof(Index));

            try
            {
                _services.DeleteCorporateCustomer(corpoCustomer.Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
                //return View();
            }


        }
    }
}
