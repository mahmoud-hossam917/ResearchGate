using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResearchGateProject.Models;

namespace ResearchGateProject.Controllers
{
    public class CommentController : Controller
    {
        Dbcontext DB = new Dbcontext();
        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddComment(int paperID, string content)
        {
            Comment comment = new Comment();
            comment.paperID = paperID;
            comment.content = content;
            DB.comments.Add(comment);
            DB.SaveChanges();

            return View();
        }
    }
}