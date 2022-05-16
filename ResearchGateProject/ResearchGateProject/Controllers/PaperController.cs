﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResearchGateProject.Models;

namespace ResearchGateProject.Controllers
{
   
    public class PaperController : Controller,Modify
    {
        Dbcontext DB = new Dbcontext();
       
        public List<Catagory> GetCatagories()
        {
            List<Catagory> catagories = new List<Catagory>();
            catagories = (from data in DB.catagories
                          select data).ToList();
            return catagories;
        }
        // GET: Paper
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddPaper()
        {
           
            return View(GetCatagories());
        }
        [HttpPost]
        public ActionResult AddPaper(Paper paper)
        {
            paper.Date = DateTime.UtcNow;
            paper.AuthorID =(int) Session["ID"];
         
          
            DB.papers.Add(paper);
         
            DB.SaveChanges();

          
            return View(GetCatagories());
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
        List<Comment> GetAllComments(int id)
        {
            List<Comment> comments = new List<Comment>();
            comments = (from data in DB.comments
                        where data.paperID == id
                        select data).ToList();
            return comments;
        }
        [HttpGet]
        public ActionResult ViewPaper(Paper paper)
        {
            ViewBag.comments = GetAllComments(paper.ID);
            return PartialView(paper);
        }
        public Paper GetPaper(int id)
        {
            Paper paper = new Paper();
            paper = (from data in DB.papers
                     where (data.ID == id)
                     select data).FirstOrDefault();
            return paper;
        }
     

        public ActionResult Delete(int id)
        {
            Paper paper = new Paper();
            paper = GetPaper(id);
            DB.papers.Remove(paper);
            DB.SaveChanges();
            return View();
        }
    }
}