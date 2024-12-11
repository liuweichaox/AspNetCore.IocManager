using AscNetCore.IocManager.DependencyInjection;
using Autofac;

namespace AscNetCore.IocManager
{

    /// <summary>
    /// Application拓展类
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// 注入Application容器
        /// </summary>
        /// <returns></returns>
        public static ContainerBuilder RegisterService(this ContainerBuilder builder)
        {
            var assembly = typeof(ApplicationExtensions).Assembly;
            builder.RegisterAssembly(assembly);
            return builder;
        }
    }
}
