using System;
using System.Collections.Generic;
using System.Text;

namespace AscNetCore.IocManager.DependencyInjection
{
    /// <summary>
    /// 确定接口或类的生存期
    /// 作用域模式，服务在每次请求时被创建，整个请求过程中都贯穿使用这个创建的服务。
    /// </summary>
    public interface ILifetimeScopeDependency : ILifetime { }
}
