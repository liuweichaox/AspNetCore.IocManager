using AscNetCore.IocManager.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AscNetCore.IocManager
{
    public static class ServiceExtensions
    {
        public static IServiceCollection UseService(this IServiceCollection services)
        {
            var assembly = typeof(ServiceExtensions).Assembly;
            services.AddAssembly(assembly);
            return services;
        }
    }
}
