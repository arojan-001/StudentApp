using Microsoft.AspNet.Identity.Owin;
using Student.BLL.DTO;
using Student.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student.WebUI.Controllers
{
    public class OptionsController : Controller
    {       
        private IQuestionService QuestionService
        { get { return HttpContext.GetOwinContext().GetUserManager<IQuestionService>(); } }
        private IOptionsService OptionService
        { get { return HttpContext.GetOwinContext().GetUserManager<IOptionsService>(); } }
        private IExamService ExamService
        { get { return HttpContext.GetOwinContext().GetUserManager<IExamService>(); } }
       
        // GET: Options
        public ActionResult Index()
        {
            return View();
        }

        // GET: Options/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Options/Create
        public ActionResult CreateOption(int questionId = 2)
        {
            var model = new OptionsDTO();
            model.QuestionId = questionId;
            return View(model);
        }

        // POST: Options/Create
        [HttpPost]
        public ActionResult CreateOption(OptionsDTO model)
        {
            try
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
            catch
            {
                return View();
            }
        }

        // GET: Options/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Options/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Options/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Options/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
