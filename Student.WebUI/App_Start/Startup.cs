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
            app.CreatePerOwinContext<IStudentService>(CreateStudentService);
            app.CreatePerOwinContext<ILessonService>(CreateLessonService);
            app.CreatePerOwinContext<IExamService>(CreateExamService);
            app.CreatePerOwinContext<IQuestionService>(CreateQuestionService);
            app.CreatePerOwinContext<IOptionsService>(CreateOptionsService);
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
        private IStudentService CreateStudentService()
        {
            return serviceCreator.CreateStudentService("DefaultConnection1");
        }
        private ILessonService CreateLessonService()
        {
            return serviceCreator.CreateLessonService("DefaultConnection1");
        }
        private IExamService CreateExamService()
        {
            return serviceCreator.CreateExamService("DefaultConnection1");
        }
        private IQuestionService CreateQuestionService()
        {
            return serviceCreator.CreateQuestionService("DefaultConnection1");
        }
        private IOptionsService CreateOptionsService()
        {
            return serviceCreator.CreateOptionsService("DefaultConnection1");
        }
    }
    
}