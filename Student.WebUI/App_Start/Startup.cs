using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Student.BLL.Services;
using Microsoft.AspNet.Identity;
using Student.BLL.Interfaces;

[assembly: OwinStartup(typeof(Student.WebUI.App_Start.Startup))]

namespace Student.WebUI.App_Start
{
    public class Startup
    {
        IServiceCreator serviceCreator = new ServiceCreator();
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<IUserService>(CreateUserService);
            app.CreatePerOwinContext<IStudentGroupService>(CreateStudentGroupService);
            app.CreatePerOwinContext<ILessonService>(CreateLessonService);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }

        private IUserService CreateUserService()
        {
            return serviceCreator.CreateUserService("DefaultConnection");
        }

        private IStudentGroupService CreateStudentGroupService()
        {
            return serviceCreator.CreateStudentGroupService("DefaultConnection1");
        }
        private ILessonService CreateLessonService()
        {
            return serviceCreator.CreateLessonService("DefaultConnection1");
        }
    }
    
}