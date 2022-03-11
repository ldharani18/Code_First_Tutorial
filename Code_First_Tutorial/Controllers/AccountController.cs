using Code_First_Tutorial.Models;
using Code_First_Tutorial.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Code_First_Tutorial.Controllers
{
    public class AccountController : Controller
    {
        private StoreContext _context;
        public AccountController()
        {
            _context = new StoreContext();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            if(!ModelState.IsValid)
            {
                return View("Register",user);
            }
            //To prevent duplicate insertion 
            if(_context.Users.Where(u => u.Email == user.Email || u.UserName==user.UserName).Any())
            {
                ModelState.AddModelError("Email", "Username or email already exists");
                return View("Register", user);
            }
            _context.Users.Add(user);
            _context.SaveChanges();
            return Content("Your registration is performed successfully.Please Login");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginFormViewModel user)
        {
            if(!ModelState.IsValid)
            {
                return View("Login", user);
            }
            var loginuser = _context.Users.Where(u => u.UserName == user.UserName && u.Password==user.Password && u.IsActive==true).FirstOrDefault();
            if(loginuser==null)
            {
                ModelState.AddModelError("UserName", "Username or Password is incorrect.Please try with correct UserName and Password");
                return View("Login", user);
            }
            else
            {
                Session["Username"]=loginuser.UserName;
                return RedirectToAction("Index","Home");
            }
            
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}