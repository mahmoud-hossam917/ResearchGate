using ResearchGateProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResearchGateProject.Controllers
{
    public class HomeController : Controller
    {
        Dbcontext DB = new Dbcontext();
        public ActionResult Index()
        {
            return View();
        }
        List<Paper> GetAllPapers(int id)
        {
            List<Paper> papers = new List<Paper>();
            papers = (from data in DB.papers
                      where (data.AuthorID != id)
                      select data).ToList();
            return papers;
        }
        [HttpGet]
        public ActionResult ViewHome()
        {
            return PartialView("ViewHome",GetAllPapers((int)Session["ID"]));
        }
        [HttpPost]
        public ActionResult Search(SearchModel search)
        {
            List<User> users = (from data in DB.users
                         where (data.university == search.need ||
                         data.email == search.need || data.Name == search.need)
                         select data).ToList();
            return View(users);
        }
        public Author PutUserIntoAuthor(User user)
        {
            Author author = new Author();
            author.ID = user.ID;
            author.Name = user.Name;
            author.email = user.email;
            author.password = user.password;
            author.university = user.university;
            author.department = user.department;
            author.adderss = user.adderss;
            author.age = user.age;
            author.image = user.image;
            author.role = user.role;
            author.phoneNumber = user.phoneNumber;
            return author;
        }
        [HttpGet]
        public ActionResult OtherProfile(User user)
        {
            Author author = new Author();
            author = PutUserIntoAuthor(user);
            UserController userController = new UserController();
            author.papers = userController.GetAllPapers(user.ID);
          
            return View(author);
        }
    }
}