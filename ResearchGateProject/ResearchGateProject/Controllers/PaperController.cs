using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResearchGateProject.Models;

namespace ResearchGateProject.Controllers
{
    public class PaperController : Controller
    {
        Dbcontext DB = new Dbcontext();
        // GET: Paper
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddPaper(Paper paper, int userID, int catagoryID)
        {
            paper.AuthorID = userID;
            paper.catagoryID = catagoryID;
            DB.papers.Add(paper);
            DB.SaveChanges();
            return View();
        }
        public ActionResult DeletePaper(int paperID)
        {
            Paper paper = new Paper();
            paper = (from data in DB.papers
                     where (data.ID == paperID)
                     select data).FirstOrDefault();
            DB.papers.Remove(paper);
            DB.SaveChanges();
            return View();
        }
        public ActionResult EditPaper(Paper paper)
        {
            Paper currentPaper = new Paper();
            currentPaper = (from data in DB.papers
                            where paper.ID == data.ID
                            select data).FirstOrDefault();
            currentPaper.catagory = paper.catagory;
            currentPaper.content = paper.content;
            currentPaper.Date = paper.Date;
            currentPaper.dislike = paper.dislike;
            currentPaper.like = paper.like;
            DB.SaveChanges();
            return View();
        }

    }
}