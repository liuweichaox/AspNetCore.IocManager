using AscNetCore.IocManager.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AscNetCore.IocManager.Services
{
    public class UserService : IUserService, ISingletonDependency
    {
        public string GetUserNameById(string Id)
        {
            return "刘大大";
        }
    }
}
