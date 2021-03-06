﻿using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutomatedQuestionPaper.Areas.Staff.Models;
using AutomatedQuestionPaper.Controllers;
using AutomatedQuestionPaper.Models;

namespace AutomatedQuestionPaper.Areas.Staff.Controllers
{
    [SessionCheckStaff]
    public class FileUploadController : AlertController
    {
        private readonly DatabaseContext _context = new DatabaseContext();

        // GET: Staff/FileUpload
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult QuestionFileUpload(string selectedFileType, HttpPostedFileBase fileControl,
            string selectedSemester, string selectedDepartment, string selectedSubject, string selectedUnit,
            string ExamType, string chapterName)
        {
            var extension = Path.GetExtension(fileControl.FileName);

            var subjectId = _context.Courses.FirstOrDefault(u => u.CourseName == selectedSubject)?.Courseid;

            var departmentId = DatabaseData.GetDepartmentInfo(selectedDepartment)?.Id;

            var semesterId = DatabaseData.GetSemesterInfo(selectedSemester)?.Id;

            var unit = Convert.ToInt32(selectedUnit);

            var type = (int) Enum.Parse(typeof(ExamType), ExamType);

            var chapterId = _context.Chapters.FirstOrDefault(x =>
                x.SemesterId == semesterId && x.DepartmentId == departmentId && x.CourseId == subjectId &&
                x.UnitNo == unit && x.ChapterName == chapterName)?.Id;

            // Word file
            if (extension == ".docx" || extension == ".doc")
            {
                ProcessFile.WordFile(fileControl);
            }

            // CSV file
            else if (extension == ".csv" || extension == ".CSV")
            {
                var data = ProcessFile.CsvFile(fileControl);
                if (data.questions == null)
                {
                    TempData["UploadError"] = data.error;
                    return View("Index");
                }

                foreach (var q in data.questions)
                    _context.Questions.Add(new Question
                    {
                        ChapterId = chapterId,
                        CourseId = subjectId,
                        DepartmentId = Convert.ToString(departmentId),
                        DifficultyLevel = q.Level,
                        QuestionText = q.Question,
                        QuestionType = type,
                        SemesterId = Convert.ToString(semesterId),
                        UnitId = unit
                    });
                _context.SaveChangesAsync();

                Alert("Success", "Question set added successfully", Enums.NotificationType.success);

                return RedirectToAction("Index", "Question");
            }
            return null;
        }
    }
}