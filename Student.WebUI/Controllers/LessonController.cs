using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Student.BLL.Interfaces;
using Microsoft.AspNet.Identity.Owin;
using Student.WebUI.Models;
using Student.DAL.EF;
using Student.DAL.Entities;

namespace Student.WebUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class LessonController : Controller
    {
        EFDbContext LessonContext;
        private ILessonService LessonService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ILessonService>();
            }
        }
        public LessonController()
        {
            LessonContext = new EFDbContext("DefaultConnection1");
        }
        public ActionResult Index()
        {
            ViewBag.Groups = LessonContext.StudentGroups.ToList();
            var lessons = new LessonsViewModel {Lessons = LessonContext.Lessons.ToList(), Exams = LessonContext.Exams.ToList() };
            return View(lessons);
        }
        public ActionResult AddLesson()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddLesson(Lesson lesson)
        {
            LessonContext.Lessons.Add(lesson);
            LessonContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetGroupLessons(int id)
        {
            ViewBag.GroupId = id;
            var lessons = LessonContext.Lessons.Where(t => LessonContext.GroupLessons.Any(p => p.GroupId == id && p.LessonId == t.LessonId)).ToList();
            LessonContext.SaveChanges();
            return View(lessons);
        }

        [HttpGet]
        public ActionResult AddLessonToGroup(int GroupId)
        {
            ViewBag.GroupId = GroupId;
            ViewBag.Lessons = LessonContext.Lessons.Where(p => !LessonContext.GroupLessons.Any(t => t.GroupId == GroupId && t.LessonId == p.LessonId)).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult AddLessonToGroup(int LessonId, int GroupId)
        {
            LessonContext.GroupLessons.Add(new GroupLesson { LessonId = LessonId, GroupId = GroupId });
            LessonContext.SaveChanges();
            return RedirectToAction("Index","Admin");
        }

        [HttpPost]
        public ActionResult DeleteGroupLesson(int LessonId,int GroupId)
        {
            var a = LessonContext.GroupLessons.FirstOrDefault(p =>p.LessonId == LessonId && p.GroupId == GroupId);
            LessonContext.GroupLessons.Remove(a);
            LessonContext.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        public ActionResult AddExam()
        {
            ViewBag.Groups = LessonContext.StudentGroups.ToList();
            ViewBag.Lessons = LessonContext.Lessons.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult AddExam(Exam exam)
        {
            LessonContext.Exams.Add(exam);
            LessonContext.SaveChanges();
            return RedirectToAction("Index", "Lesson");
        }

        [HttpGet]
        public ActionResult AddEvaluation(string Userid, int GroupId)
        {
            ViewBag.lessons = LessonContext.Lessons.Where(t => LessonContext.GroupLessons.Any(p => p.GroupId == GroupId && p.LessonId == t.LessonId)).ToList();
            ViewBag.UserId = Userid;
            ViewBag.Exams = LessonContext.Exams.Where(p => p.GroupId == GroupId).ToList();

            return View();
        }

        [HttpPost]
        public ActionResult AddEvaluation(Evaluation evaluation)
        {
            LessonContext.Evaluations.Add(evaluation);
            LessonContext.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        public ActionResult Averages(string Userid, int GroupId)
        {
            var evals = from u in LessonContext.Evaluations.Where(p => p.UserId == Userid)
                        join c in LessonContext.Exams on u.ExamId equals c.ExamId
                        join l in LessonContext.Lessons on c.LessonId equals l.LessonId
                        select new StudentViewModel { Date = c.ExamDate, Lesson = l.Name, Value = u.Value };
            ViewBag.Userid = Userid;
            ViewBag.Evals = evals.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Averages(Averages averages)
        {
            double a = 0;
            var evals =  LessonContext.Evaluations.Where(p => p.UserId == averages.UserId).ToList();
            var exams = LessonContext.Exams.ToList();
            exams = exams.Where(p => evals.Any(t => t.ExamId == p.ExamId) && p.ExamDate <= averages.date2 && p.ExamDate >= averages.date1).ToList();
            evals = evals.Where(p => exams.Any(t => t.ExamId == p.ExamId)).ToList();
            if (evals.Count != 0)
            {
                a = evals.Average(p => p.Value) / evals.Count;
            }
            ViewBag.avg = a.ToString();

            var evals1 = from u in LessonContext.Evaluations.Where(p => p.UserId == averages.UserId)
                        join c in LessonContext.Exams on u.ExamId equals c.ExamId
                        join l in LessonContext.Lessons on c.LessonId equals l.LessonId
                        select new StudentViewModel { Date = c.ExamDate, Lesson = l.Name, Value = u.Value };
            ViewBag.Evals = evals1.ToList();
            return View();
        }
    }
}