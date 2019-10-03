using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace AscNetCore.IocManager.DependencyInjection
{
    /// <summary>
    /// .NET Core 依赖注入拓展
    /// </summary>
    public static class DependencyInjectionExtensions
    {
        /// <summary>
        /// 注册程序集组件
        /// </summary>
        /// <param name="services"></param>
        /// <param name="assemblies"></param>
        /// <returns></returns>
        public static IServiceCollection AddAssembly(this IServiceCollection services, params Assembly[] assemblies)
        {
            if (assemblies == null || assemblies.Count() == 0)
            {
                throw new Exception("assemblies cannot be empty.");
            }
            foreach (var assembly in assemblies)
            {
                RegisterDependenciesByAssembly<ISingletonDependency>(services, assembly);
                RegisterDependenciesByAssembly<ITransientDependency>(services, assembly);
                RegisterDependenciesByAssembly<ILifetimeScopeDependency>(services, assembly);
            }
            return services;
        }
        public static void RegisterDependenciesByAssembly<TServiceLifetime>(IServiceCollection services, Assembly assembly)
        {
            var types = assembly.GetTypes().Where(x => typeof(TServiceLifetime).GetTypeInfo().IsAssignableFrom(x) && x.GetTypeInfo().IsClass && !x.GetTypeInfo().IsAbstract && !x.GetTypeInfo().IsSealed).ToList();
            foreach (var type in types)
            {
                var itype = type.GetTypeInfo().GetInterfaces().FirstOrDefault(x => x.Name.ToUpper().Contains(type.Name.ToUpper()));
                if (itype != null)
                {
                    var serviceLifetime = FindServiceLifetime(typeof(TServiceLifetime));
                    services.Add(new ServiceDescriptor(itype, type, serviceLifetime));
                }
            }
        }

        private static ServiceLifetime FindServiceLifetime(Type type)
        {
            if (type == typeof(ISingletonDependency))
            {
                return ServiceLifetime.Singleton;
            }
            if (type == typeof(ITransientDependency))
            {
                return ServiceLifetime.Transient;
            }
            if (type == typeof(ILifetimeScopeDependency))
            {
                return ServiceLifetime.Scoped;
            }

            throw new ArgumentOutOfRangeException($"Provided ServiceLifetime type is invalid. Lifetime:{type.Name}");
        }

        /// <summary>
        /// 注册IocManager
        /// 在ConfigureServices方法最后一行使用
        /// </summary>
        /// <param name="services"></param>
        public static void AddIocManager(this IServiceCollection services)
        {
            services.AddSingleton<IIocManager, IocManager>(provide =>
            {
                IocManager.Instance.ServiceProvider = provide;
                return IocManager.Instance;
            });
        }
    }
}
