﻿using System.Web.Mvc;

namespace AutomatedQuestionPaper.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("/home")]
        public ActionResult Index()
        {
            Session["Username"] = Session["Staff_Name"] = null;
            return View();
        }
    }
}