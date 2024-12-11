using System;
using System.Collections.Generic;
using System.Text;

namespace AscNetCore.IocManager.DependencyInjection
{
    /// <summary>
    /// <see cref="IIocManager"/>管理器实现类
    /// </summary>
    public class IocManager : IIocManager
    {
        static IocManager()
        {
            Instance = new IocManager();
        }
        public static IocManager Instance { get; private set; }
        public IServiceProvider ServiceProvider { get; set; }
    }
}
