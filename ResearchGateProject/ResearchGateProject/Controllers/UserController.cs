using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResearchGateProject.Models;

namespace ResearchGateProject.Controllers
{
    public class UserController : Controller
    {
        Dbcontext DB = new Dbcontext();
        // GET: User
        public ActionResult Index()
        {
            return View("Index");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            User user = new User();
            user = (from data in DB.users
                    where (data.email == loginModel.email && data.password == loginModel.password)
                    select data).FirstOrDefault();
            if (user != null)
            {
                return View("Login");
                

            }
              
            else
                return View("Login");
        }
        [HttpGet]
        public ActionResult Register()
        {
           
            return View("Register");
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            DB.users.Add(user);
            DB.SaveChanges();
            return View("Login");
        }
        public ActionResult EditProfile(User user)
        {
            User currentUser = new User();
            currentUser = (from data in DB.users
                           where (user.ID == data.ID)
                           select data).FirstOrDefault();
            currentUser.Name = user.Name;
            currentUser.password = user.password;
            currentUser.image = user.image;
            currentUser.phoneNumber = user.phoneNumber;
            currentUser.role = user.role;
            currentUser.university = user.university;
            DB.SaveChanges();
            return View();
        }
    }
}