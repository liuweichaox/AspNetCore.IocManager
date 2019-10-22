using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AscNetCore.IocManager.Models;
using AscNetCore.IocManager.DependencyInjection;
using AscNetCore.IocManager.Services;
using Microsoft.Extensions.DependencyInjection;
namespace AscNetCore.IocManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly IIocManager _iocManager;
        public HomeController(IIocManager iocManager)
        {
            _iocManager = iocManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public string test1()
        {
            //通过注入获取IocManager实例
            var _userService = _iocManager.ServiceProvider.GetService<IUserService>();
            var userName = _userService.GetUserNameById("1");
            return userName;
        }

        public string test2()
        {
            //通过IocManager获取IIocManager实例
            var _userService = AscNetCore.IocManager.DependencyInjection.IocManager.Instance.ServiceProvider.GetService<IUserService>();
            var userName = _userService.GetUserNameById("1");
            return userName;
        }

        public string test3([FromServices]IUserService _userService)
        {
            //通过注入获取Service实例
            var userName = _userService.GetUserNameById("1");
            return userName;
        }
        public string test4()
        {
            return "";
        }
    }
}
