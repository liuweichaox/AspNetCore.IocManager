using AscNetCore.IocManager.DependencyInjection;

namespace AscNetCore.IocManager.Services
{
    public class UserService : IUserService, ISingletonDependency
    {
        public string GetUserNameById(string id)
        {
            return $"刘大大{id}";
        }
    }
}
