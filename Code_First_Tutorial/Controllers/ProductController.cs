using Code_First_Tutorial.Models;
using Code_First_Tutorial.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;

namespace Code_First_Tutorial.Controllers
{
    public class ProductController : Controller
    {
        private StoreContext _context;
        //ctor+double tab to create constructor
        public ProductController()
        {
            _context = new StoreContext();
        }
        public ActionResult Create()
        {
            var category = _context.Categories.ToList();
            var viewmodel = new ProductFromViewModel
            {
                Product=new Product(),
                Categories = category
            };

            return View(viewmodel);
        }
        //[Bind(Include="id,Name,CategoryId,Price,Description")]
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if(ModelState.IsValid)
            {
                if (product.Id > 0)
                    _context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                else
                    _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create",product);
            }
            
        }
        public ActionResult Edit(int? id)
        {
            if(id== null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var product = _context.Products.SingleOrDefault(p => p.Id == id);
            if(product == null)
                return HttpNotFound();
            var viewmodel = new ProductFromViewModel
            {
                Product = product,
                Categories = _context.Categories.ToList()
            };
            return View("Create",viewmodel);

        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Product product = _context.Products.Find(id);
            if (product == null)
                return HttpNotFound();
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Product
        public ActionResult Index()
        {
            var products = _context.Products.Include(c=>c.Category).ToList();
            return View(products);
        }
        protected override void Dispose(bool disposing)
        {
            if(disposing)
                _context.Dispose();
            base.Dispose(disposing);
        }
    }
}