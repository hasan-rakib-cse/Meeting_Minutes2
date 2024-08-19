using Meeting_Minutes2.Interfaces;
using Meeting_Minutes2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Meeting_Minutes2.Controllers
{
    public class ProductServiceController : Controller
    {
        private readonly IProductServices _services;

        public ProductServiceController(IProductServices services)
        {
            _services = services;
        }

        public IActionResult Index()
        {
            var proService = _services.GetProductServiceList();
            return View(proService);
        }

        public IActionResult Details(int id)
        {
            ProductService proService = _services.GetProductServiceById(id);
            if (proService == null)
            {
                return NotFound();
            }
            return View(proService);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductService proService)
        {
            if (ModelState.IsValid)
            {
                _services.CreateProductService(proService);
                return RedirectToAction(nameof(Index));
            }
            return View(proService);
        }

        public IActionResult Edit(int id)
        {
            var proService = _services.GetProductServiceById(id);
            if (proService == null)
            {
                return NotFound();
            }
            return View(proService);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ProductService proService)
        {
            if (id != proService.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _services.UpdateProductService(proService);
                return RedirectToAction(nameof(Index));
            }
            return View(proService);
        }

        public IActionResult Delete(int id)
        {
            var proService = _services.GetProductServiceById(id);
            if (proService == null)
            {
                return NotFound();
            }
            return View(proService);

            //ProductService proService = _services.GetProductServiceById(id);
            //return View(proService);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(ProductService proService)
        {
            //_services.DeleteProductService(id);
            //return RedirectToAction(nameof(Index));

            try
            {
                _services.DeleteProductService(proService.Id);
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
