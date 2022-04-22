﻿using Student.DAL.EF;
using Student.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student.WebUI.Controllers
{
    public class HomeController : Controller
    {
        EFDbContext LessonContext;

        ApplicationContext ClientContext { get; }

        public HomeController()
        {
            LessonContext = new EFDbContext("DefaultConnection1");
            ClientContext = new ApplicationContext("DefaultConnection");
        }
        public ActionResult Index(string UserId)
        {
            var evals = from u in LessonContext.Evaluations.Where(p => p.UserId == UserId)
                        join c in LessonContext.Exams on u.ExamId equals c.ExamId
                        join l in LessonContext.Lessons on c.LessonId equals l.LessonId
                        select new StudentViewModel { Date = c.ExamDate, Lesson = l.Name, Value = u.Value };

            //IQueryable<Guid> ExamIds = Enumerable.Empty<Guid>().AsQueryable();
            //var evals = from u in ClientContext.ClientProfiles.Where(p => p.Id == UserId)
            //            join sg in LessonContext.GroupLessons on u.StudentGroupId equals sg.GroupId
            //            join e in LessonContext.Exams on sg.LessonId equals e.LessonId
            //            join l in LessonContext.Lessons on e.LessonId equals l.LessonId
            //            select new StudentViewModel { Date = e.ExamDate, Lesson = l.Name, Value = new double() };

            return View(evals.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}