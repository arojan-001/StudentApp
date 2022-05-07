﻿using Microsoft.AspNet.Identity.Owin;
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

        [HttpGet]
        public ViewResult Index(int examid)
        {
            List<QuestionAnswerViewModel> questionAnswer = new List<QuestionAnswerViewModel>();
            
            var id = examid;
            
            foreach (var item in QuestionService.GetByExamId(id))
            {
                var q = new QuestionAnswerViewModel(){options = OptionService.GetbyQuestionid(item.Id), question = item };
                questionAnswer.Add(q);
            }

            return View(questionAnswer);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ViewResult AddQuestion(int examId)
        {
            var model = new QuestionBankDTO();
            model.ExamId = examId;
            //ViewBag.Lessons = LessonService.GetAll();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddQuestion(QuestionBankDTO model)
        {
            
            if (ModelState.IsValid)
            {
                var op = QuestionService.Create(model);
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
        [HttpGet]
        public ViewResult AddOption(int questionId = 2)/*(int questionId)*/
        {
            var model = new OptionsDTO();
            model.QuestionId = questionId;
            return View(model);
        }
        [HttpPost]
        public ActionResult AddOption(OptionsDTO model)
        {

            if (ModelState.IsValid)
            {
                var op = OptionService.Create(model);
                TempData["message"] = string.Format("{0} has been saved", op.Message);
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