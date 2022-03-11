﻿using Code_First_Tutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Code_First_Tutorial.Controllers
{
    public class SupplierController : Controller
    {
        private StoreContext _context;
        public SupplierController()
        {
            _context = new StoreContext();
        }
        // GET: Supplier
        public ActionResult Index()
        {
            var suppliers=_context.Suppliers.ToList();
            ViewBag.Suppliers = suppliers;
            return View();
        }
        [HttpPost]
        public ActionResult SaveSupplier(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            bool result = false;
            var supplier= _context.Suppliers.FirstOrDefault(x => x.Id == id);
            if (supplier != null)
            {
                _context.Suppliers.Remove(supplier);
                _context.SaveChanges();
                result = true;
            }
           return Json(result,JsonRequestBehavior.AllowGet);
        }
    }
}