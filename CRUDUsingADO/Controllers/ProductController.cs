using CRUDUsingADO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDUsingADO.Controllers
{
    public class ProductController : Controller
    {
        private readonly IConfiguration _configuration;
        private ProductCRUD db;
        public ProductController(IConfiguration configuration)
        {
            _configuration = configuration;
            db= new ProductCRUD(_configuration);
        }

        // GET: ProductController
        public ActionResult Index()
        {
            var list = db.GetProducts();
            return View(list);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var prod = db.GetProductById(id);
            return View(prod);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(prod product)
        {
            try
            {
                int result = db.AddProduct(product);
                if(result>0)
                return RedirectToAction(nameof(Index));
                else return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var prod = db.GetProductById(id);
            return View(prod);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(prod product)
        {
            try
            {
                int result = db.EditProduct(product);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var prod = db.GetProductById(id);
            return View(prod);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = db.DeleteProduct(id);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
