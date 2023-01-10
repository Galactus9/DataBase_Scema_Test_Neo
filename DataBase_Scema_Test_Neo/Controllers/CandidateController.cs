using DataBase_Scema_Test_Neo.Data;
using DataBase_Scema_Test_Neo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataBase_Scema_Test_Neo.Controllers
{
    public class CandidateController : Controller
    {
        // GET: Candidate
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create(Candidate candidate)
        {
            
            return View();
        }
        public ActionResult Save(Candidate candidate)
        {
            MyDbContext context = new MyDbContext();
            context.Candidates.AddOrUpdate(candidate);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}