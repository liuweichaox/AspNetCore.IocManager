namespace AscNetCore.IocManager.DependencyInjection
{
    /// <summary>
    /// 确定接口或类的生存期
    /// 单例模式，所有服务请求都将会返回同一个实例。
    /// </summary>
    public interface ISingletonDependency : ILifetime { }
}
