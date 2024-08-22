using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductDataAccessLayer _dataAccessLayer;

        public ProductController(IProductDataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }

        // GET: ProductController
        public IActionResult Index()
        {
            List<Product> products = _dataAccessLayer.GetAllProducts().ToList();
            return View(products);
        }

        // GET: ProductController/Details/5
        public IActionResult Details(int id)
        {
            Product product = _dataAccessLayer.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // GET: ProductController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _dataAccessLayer.AddProduct(product);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    // Log the error
                    ModelState.AddModelError("", "No se pudo guardar el producto. Inténtelo de nuevo.");
                }
            }
            return View(product);
        }

        // GET: ProductController/Edit/5
        public IActionResult Edit(int id)
        {
            Product product = _dataAccessLayer.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _dataAccessLayer.UpdateProduct(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = _dataAccessLayer.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int ProductId)
        {
            try
            {
                _dataAccessLayer.DeleteProduct(ProductId);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Manejo de errores
                ModelState.AddModelError("", "No se pudo eliminar el producto. " + ex.Message);
                return View();
            }
        }

    }

}