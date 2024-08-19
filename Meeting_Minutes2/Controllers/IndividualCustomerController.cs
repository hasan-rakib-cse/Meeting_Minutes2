using Meeting_Minutes2.Interfaces;
using Meeting_Minutes2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Meeting_Minutes2.Controllers
{
    public class IndividualCustomerController : Controller
    {
        private readonly IIndividualCustomerServices _services;

        public IndividualCustomerController(IIndividualCustomerServices services)
        {
            _services = services;
        }

        public IActionResult Index()
        {
            var indiCustomers = _services.GetIndividualCustomerList();
            return View(indiCustomers);
        }

        public IActionResult Details(int id)
        {
            IndividualCustomer indiCustomer = _services.GetIndividualCustomerById(id);
            if (indiCustomer == null)
            {
                return NotFound();
            }
            return View(indiCustomer);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IndividualCustomer indiCustomer)
        {
            if (ModelState.IsValid)
            {
                _services.CreateIndividualCustomer(indiCustomer);
                return RedirectToAction(nameof(Index));
            }
            return View(indiCustomer);
        }

        public IActionResult Edit(int id)
        {
            var indiCustomer = _services.GetIndividualCustomerById(id);
            if (indiCustomer == null)
            {
                return NotFound();
            }
            return View(indiCustomer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IndividualCustomer indiCustomer)
        {
            if (id != indiCustomer.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _services.UpdateIndividualCustomer(indiCustomer);
                return RedirectToAction(nameof(Index));
            }
            return View(indiCustomer);
        }

        public IActionResult Delete(int id)
        {
            IndividualCustomer indiCustomer = _services.GetIndividualCustomerById(id);
            
            if (indiCustomer == null)
            {
                return NotFound();
            }
            return View(indiCustomer);

            //var indiCustomer = _services.GetIndividualCustomerById(id);
            //return View(corpoCustomer);
    }


    [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(IndividualCustomer indiCustomer)
        {
            //_services.DeleteCorporateCustomer(id);
            //return RedirectToAction(nameof(Index));

            try
            {
                _services.DeleteIndividualCustomer(indiCustomer.Id);
                //return RedirectToAction("Index");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw ex;
                //return View();
            }


        }
    }
}
