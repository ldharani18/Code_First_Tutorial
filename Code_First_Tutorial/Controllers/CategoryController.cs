using Code_First_Tutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace Code_First_Tutorial.Controllers
{
    public class CategoryController : Controller
    {

        private StoreContext _context;

        public CategoryController()
        {
            _context = new StoreContext();
        }
        // GET: Category
        public ActionResult Index()
        {
            var categories=_context.Categories.ToList();
            return View(categories);
        }
        public ActionResult Create()
        {
            return View(new Category { Id=0});
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if(ModelState.IsValid)
            {
                if (category.Id > 0)
                    _context.Entry(category).State = System.Data.Entity.EntityState.Modified;
                else
                _context.Categories.Add(category);

                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create", category);
        }
        public ActionResult Delete(int? id)
        {
            if(id== null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var category = _context.Categories.SingleOrDefault(c => c.Id == id);
            if(category == null)
                return HttpNotFound();
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var category=_context.Categories.SingleOrDefault(c=>c.Id == id);
            if (category == null)
                return HttpNotFound();

            return View("Create",category);
        }
        public ActionResult Search(string search)
        {
            var _category=_context.Categories.Where(c=>c.Name.Contains(search)).ToList();
            return View("Index", _category);
        }
        protected override void Dispose(bool disposing)
        {
            if(disposing)
                _context.Dispose();
            base.Dispose(disposing);
        }
    }
}