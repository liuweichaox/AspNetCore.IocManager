namespace AscNetCore.IocManager.DependencyInjection
{
    /// <summary>
    /// 确定接口或类的生存期
    /// 瞬态模式，每次请求时都会创建。
    /// </summary>
    public interface ITransientDependency : ILifetime { }
}
