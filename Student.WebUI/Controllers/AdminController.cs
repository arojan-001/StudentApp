using Microsoft.AspNet.Identity.Owin;
using Student.BLL.Interfaces;
using Student.DAL.EF;
using Student.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student.WebUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        EFDbContext LessonContext;
        private IStudentGroupService StudentGroupService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IStudentGroupService>();
            }
        }
        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }

        public AdminController()
        {
            LessonContext = new EFDbContext("DefaultConnection1");
        }

        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.Eval = LessonContext.Evaluations.ToList();
            StudentGroupListViewModel studentGroup = new StudentGroupListViewModel() { StudentGroupList = StudentGroupService.GetAll() };
            BaseViewModel baseVM = new BaseViewModel { StudentGroup = studentGroup, Users = UserService.getUserList(null) }; 
            return View(baseVM);
        }
    }
}