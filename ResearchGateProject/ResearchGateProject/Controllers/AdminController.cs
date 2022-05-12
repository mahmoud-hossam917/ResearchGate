using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResearchGateProject.Models;

namespace ResearchGateProject.Controllers
{
    public class AdminController : Controller,Modify
    {
        // GET: Admin
        Dbcontext DB = new Dbcontext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewUser(int authorID)
        {

            return View();
        }
        public ActionResult DeleteAccount(int userID)
        {
            User author = new User();
            author = (from data in DB.users
                      where data.ID == userID
                      select data).FirstOrDefault();
            DB.users.Remove(author);
            DB.SaveChanges();
            return View();
        }
        public ActionResult DeletePaper(int paperID)
        {
            Paper paper = new Paper();
            paper = (from data in DB.papers
                     where data.ID == paperID
                     select data).FirstOrDefault();
            DB.papers.Remove(paper);
            DB.SaveChanges();
            return View();
        }
        public ActionResult DeleteReactLike(int paperID)
        {
            Paper paper = new Paper();
            paper = (from data in DB.papers
                     where data.ID == paperID
                     select data).FirstOrDefault();
            paper.like = false;
            DB.SaveChanges();
            return View();
        }
        public ActionResult DeleteReactDislike(int paperID)
        {
            Paper paper = new Paper();
            paper = (from data in DB.papers
                     where data.ID == paperID
                     select data).FirstOrDefault();
            paper.dislike = false;
            DB.SaveChanges();
            return View();
        }

        public ActionResult Delete(int id)
        {
            User author = new User();
            UserController userController = new UserController();
            author = userController.GetUser(id);
            DB.users.Remove(author);
            DB.SaveChanges();
            return View();
        }
    }
}