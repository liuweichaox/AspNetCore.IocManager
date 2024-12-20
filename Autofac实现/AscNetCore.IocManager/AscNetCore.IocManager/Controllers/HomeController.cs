﻿using Microsoft.AspNetCore.Mvc;
using AscNetCore.IocManager.DependencyInjection;
using AscNetCore.IocManager.Services;

namespace AscNetCore.IocManager.Controllers
{
    public class HomeController(IIocManager iocManager) : Controller
    {
        public string Test1()
        {
            //通过注入获取IocManager实例
            var userService = iocManager.GetInstance<IUserService>(); 
            var userName = userService.GetUserNameById("1");
            return userName;
        }
    
        public string Test2()
        {
            //通过IocManager获取IIocManager实例
            IUserService userService = IocManager.DependencyInjection.IocManager.Instance.GetInstance<IUserService>();
            var userName = userService.GetUserNameById("1");
            return userName;
        }
    
        public string Test3([FromServices]IUserService userService)
        {
            //通过注入获取Service实例
            var userName=userService.GetUserNameById("1");
            return userName;
        }
    }

}
