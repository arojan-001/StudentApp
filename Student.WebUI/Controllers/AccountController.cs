using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Student.BLL.DTO;
using Student.BLL.Infrastructure;
using Student.BLL.Interfaces;
using Student.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Student.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }

        private IStudentGroupService StudentGroupService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IStudentGroupService>();
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ActionResult Login()
        {
            AuthenticationManager.SignOut();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO { Email = model.Email, Password = model.Password };
                ClaimsIdentity claim = await UserService.Authenticate(userDto);
                if (claim == null)
                {
                    ModelState.AddModelError("", "wrong login or password.");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    if (claim.Claims.Any(p => p.Value == "admin"))
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    return RedirectToAction("Index", "Home",new { UserId = claim.Claims.FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier)?.Value });
                }
            }
            
            return View(model);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Register()
        {
            ViewBag.Groups = StudentGroupService.GetAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO
                {
                    Email = model.Email,
                    Password = model.Password,
                    Address = model.Address,
                    StudentGroupId = model.StudentGroupId,
                    Name = model.Name,
                    Role = "user"
                };
                OperationDetails operationDetails = await UserService.Create(userDto);
                if (operationDetails.Succedeed)
                    return RedirectToAction("Index", "Admin");
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }
            ViewBag.Groups = StudentGroupService.GetAll();
            return View(model);
        }
        private async Task SetInitialDataAsync()
        {
            await UserService.SetInitialData(new UserDTO
            {
                Email = "admin@mail.ru",
                UserName = "admin@mail.ru",
                Password = "admin123",
                Name = "admin admin",
                Address = "admini 1",
                Role = "admin",
            }, new List<string> { "user", "admin" });
        }
    }
}