﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutomatedQuestionPaper.Areas.Staff.Models;
using AutomatedQuestionPaper.Models;


namespace AutomatedQuestionPaper.Areas.Staff.Controllers
{
    [SessionCheckStaff]
    public class QuestionPaperRepositoryController : Controller
    {
        DatabaseContext _context = new DatabaseContext();

        // GET: Staff/QuestionPaperRepository
        public ActionResult Index()
        {
            var data = _context.ExamPapers.ToList();


            return View(data);
        }

        public ActionResult QuestionPaperView(int id)
        {
            var data = PdfHandler.DisplayPdf(id);
            return data;
        }

        public ActionResult QuestionPaperDelete(int id)
        {
            var examPaper = _context.ExamPapers.FirstOrDefault(i=>i.Id == id);
            _context.ExamPapers.Remove(examPaper);

            _context.SaveChanges();

            TempData["QuestionPaperDeleted"] = "Question paper deleted";

            return RedirectToAction("Index");
        }
    }
}