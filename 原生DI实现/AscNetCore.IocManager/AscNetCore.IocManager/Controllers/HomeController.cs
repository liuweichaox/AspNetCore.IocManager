using Microsoft.AspNetCore.Mvc;
using AscNetCore.IocManager.DependencyInjection;
using AscNetCore.IocManager.Services;
using Microsoft.Extensions.DependencyInjection;
namespace AscNetCore.IocManager.Controllers
{
    public class HomeController(IIocManager iocManager) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public string Test1()
        {
            //通过注入获取IocManager实例
            var userService = iocManager.ServiceProvider.GetService<IUserService>();
            var userName = userService.GetUserNameById("1");
            return userName;
        }

        public string Test2()
        {
            //通过IocManager获取IIocManager实例
            var userService = AscNetCore.IocManager.DependencyInjection.IocManager.Instance.ServiceProvider.GetService<IUserService>();
            var userName = userService.GetUserNameById("1");
            return userName;
        }

        public string Test3([FromServices]IUserService userService)
        {
            //通过注入获取Service实例
            var userName = userService.GetUserNameById("1");
            return userName;
        }
    }
}
