using System;
using System.Collections.Generic;
using System.Text;

namespace AscNetCore.IocManager.DependencyInjection
{
    /// <summary>
    /// 管理器接口
    /// </summary>
    public interface IIocManager
    {
        IServiceProvider ServiceProvider { get; set; }
    }
}
