using Code_First_Tutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Code_First_Tutorial.Controllers
{
    public class SliderController : Controller
    {
        private StoreContext _context;
        public SliderController()
        {
            _context = new StoreContext();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Slider slider,HttpPostedFileBase picture)
        {
            //Image Name
            string Image_Name=(picture==null)?null:System.IO.Path.GetFileName(picture.FileName);
            //Set the path of image
            string Image_Path = "~/Uploads/Slider/" + Image_Name;
            //Saving Image into Server Defined Location
            picture.SaveAs(Server.MapPath(Image_Path));
            slider.ImageName = Image_Name;
            slider.FilePath = Image_Path;
            _context.Sliders.Add(slider);
            _context.SaveChanges();
            return Content("Image Saved Successfully");
        }
        // GET: Slider
        public ActionResult Index()
        {
            return View();
        }
    }
}