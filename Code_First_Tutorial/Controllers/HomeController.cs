using Code_First_Tutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Code_First_Tutorial.Controllers
{
    
    public class HomeController : Controller
    {

        private StoreContext _context;
        public HomeController()
        {
            _context = new StoreContext();
        }
        // GET: Home
        public ActionResult Index()
        {
            var slider=_context.Sliders.ToList();
            ViewBag.slider = slider;
            return View();
        }
    }
}