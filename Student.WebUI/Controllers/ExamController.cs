using Microsoft.AspNet.Identity.Owin;
using Student.BLL.DTO;
using Student.BLL.Interfaces;
using Student.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student.WebUI.Controllers
{
    public class ExamController : Controller
    {
        private IExamService ExamService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IExamService>();
            }
        }
        private IStudentGroupService StudentGroupService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IStudentGroupService>();
            }
        }

        private ILessonService LessonService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ILessonService>();
            }
        }
        private IQuestionService QuestionService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IQuestionService>();
            }
        }
        private IOptionsService OptionsService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IOptionsService>();
            }
        }
        private IStudentService StudentService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IStudentService>();
            }
        }

        public ViewResult Index()
        {
            return View(ExamService.GetAll());
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ViewResult addExam()
        {
            ViewBag.Groups = StudentGroupService.GetAll();
            ViewBag.Lessons = LessonService.GetAll();
            return View(new ExamViewModel());
        }
        [HttpPost]
        public ActionResult addExam(ExamViewModel model)
        {
            if (ModelState.IsValid)
            {
                var op = ExamService.Create(new BLL.DTO.ExamDTO() { Id = model.Id, /*Created = DateTime.Now,*/ Duration = model.Duration, ExamDate = model.ExamDate, FullMark= model.FullMark, GroupId = model.GroupId, LessonId = model.LessonId});
                TempData["message"] = string.Format("{0} has been saved", op.Message);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                // there is something wrong with the data values
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult ExamGroup(int id)
        {
            var deletedGroup = ExamService.Delete(id);
            if (deletedGroup != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedGroup.Id);
            }
            return RedirectToAction("Index", "Admin");
        }

        public ViewResult EditExam(int id)
        {
            var exam = ExamService.GetById(id);
            var model = new ExamViewModel() { Id = exam.Id, Created = DateTime.Now, Duration = exam.Duration, ExamDate = exam.ExamDate, FullMark = exam.FullMark, GroupId = exam.GroupId, LessonId = exam.LessonId };
            return View(model);
        }

        [HttpPost]
        public ActionResult EditExam(ExamViewModel model)
        {
            if (ModelState.IsValid)
            {
                ExamService.Create(new BLL.DTO.ExamDTO() { Id = model.Id, /*Created = DateTime.Now,*/ Duration = model.Duration, ExamDate = model.ExamDate, FullMark = model.FullMark, GroupId = model.GroupId, LessonId = model.LessonId });
                TempData["message"] = string.Format("{0} has been saved", model.Id);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                // there is something wrong with the data values
                return View(model);
            }
        }


        [Authorize(Roles = "admin")]
        [HttpGet]
        public ViewResult AddQuestion()
        {
            ViewBag.Groups = StudentGroupService.GetAll();
            ViewBag.Lessons = LessonService.GetAll();
            return View(new ExamViewModel());
        }
        [HttpPost]
        public ActionResult AddQuestion(ExamViewModel model)
        {
            if (ModelState.IsValid)
            {
                var op = ExamService.Create(new BLL.DTO.ExamDTO() { Id = model.Id, /*Created = DateTime.Now,*/ Duration = model.Duration, ExamDate = model.ExamDate, FullMark = model.FullMark, GroupId = model.GroupId, LessonId = model.LessonId });
                TempData["message"] = string.Format("{0} has been saved", op.Message);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                // there is something wrong with the data values
                return View(model);
            }
        }
        [Authorize(Roles = "admin, user")]
        [HttpGet]
        public ViewResult TakeExam(int examid)
        {
            var QuestionAnswer= new List<QuestionAnswerViewModel>();
            var questions = QuestionService.GetByExamId(examid);
            foreach(var item in questions)
            {
                QuestionAnswer.Add(new QuestionAnswerViewModel { question = item, options = OptionsService.GetbyQuestionid(item.Id)});
            }
            ViewBag.QnAns = QuestionAnswer;
            return View(new ExamResultDTO());
        }
        [HttpPost]
        public ActionResult TakeExam(ExamResultDTO model)
        {
            
            if (ModelState.IsValid)
            {
                //var op = ExamService.Create(new BLL.DTO.ExamDTO() { Id = model.Id, /*Created = DateTime.Now,*/ Duration = model.Duration, ExamDate = model.ExamDate, FullMark = model.FullMark, GroupId = model.GroupId, LessonId = model.LessonId });
                //TempData["message"] = string.Format("{0} has been saved", op.Message);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                // there is something wrong with the data values
                return View(model);
            }
        }
    }
}