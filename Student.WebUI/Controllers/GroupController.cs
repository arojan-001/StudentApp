using Microsoft.AspNet.Identity.Owin;
using Student.BLL.Interfaces;
using Student.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student.WebUI.Controllers
{
    public class GroupController : Controller
    {
        private IStudentGroupService StudentGroupService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IStudentGroupService>();
            }
        }
        public ViewResult CreateGroup()
        {
            return View(new StudentGroupViewModel());
        }
        [HttpPost]
        public ActionResult CreateGroup(StudentGroupViewModel model)
        {
            if (ModelState.IsValid)
            {
                var op = StudentGroupService.Create(new BLL.DTO.StudentGroupDTO() { Id = model.Id, Name = model.Name });
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
        public ActionResult DeleteGroup(int id)
        {
            var deletedGroup = StudentGroupService.Delete(id);
            if (deletedGroup != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedGroup.Name);
            }
            return RedirectToAction("Index", "Admin");
        }

        public ViewResult EditGroup(int id)
        {
            var group = StudentGroupService.GetById(id);
            var model = new StudentGroupViewModel() { Id = group.Id, Name = group.Name };
            return View(model);
        }

        [HttpPost]
        public ActionResult EditGroup(StudentGroupViewModel model)
        {
            if (ModelState.IsValid)
            {
                StudentGroupService.Create(new BLL.DTO.StudentGroupDTO() { Id = model.Id, Name = model.Name });
                TempData["message"] = string.Format("{0} has been saved", model.Name);
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