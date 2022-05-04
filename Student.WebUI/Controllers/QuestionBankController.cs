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
    public class QuestionBankController : Controller
    {
        private IQuestionService QuestionService
        {  get {return HttpContext.GetOwinContext().GetUserManager<IQuestionService>();}}
        private IOptionsService OptionService
        { get { return HttpContext.GetOwinContext().GetUserManager<IOptionsService>();}}
        private IExamService ExamService
        { get { return HttpContext.GetOwinContext().GetUserManager<IExamService>();}}

        public ViewResult Index()
        {
            return View(ExamService.GetAll());
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ViewResult AddQuestion()
        {
            var model = new QnAnsDTO();
            ViewBag.Exams = ExamService.GetAll();
            //ViewBag.Lessons = LessonService.GetAll();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddQuestion(QnAnsDTO model)
        {
            
            if (ModelState.IsValid)
            {
                var op = QuestionService.Create(new QuestionBankDTO() { ExamId = model.question.ExamId, Id = model.question.Id, Mark = model.question.Mark, Question = model.question.Question});
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
        public ActionResult DeleteQuestion(int id)
        {
            var deletedGroup = QuestionService.Delete(id);
            if (deletedGroup != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedGroup.Id);
            }
            return RedirectToAction("Index", "Admin");
        }

        public ViewResult EditQuestion(int id)
        {
            var question = QuestionService.GetById(id);
            var options = OptionService.GetbyQuestionid(id);
            var model = new QnAnsDTO() { question = question, options = options};
            return View(model);
        }

        [HttpPost]
        public ActionResult EditQuestion(QnAnsDTO model)
        {
            if (ModelState.IsValid)
            {
                QuestionService.Create(model.question);
                foreach (var item in model.options) {
                    OptionService.Create(item);
                }
                TempData["message"] = string.Format("{0} has been saved", model.question.Id);
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