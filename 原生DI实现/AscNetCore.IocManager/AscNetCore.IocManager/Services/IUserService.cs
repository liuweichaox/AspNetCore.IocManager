using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AscNetCore.IocManager.Services
{
    public interface IUserService
    {
        string GetUserNameById(string Id);
    }
}
