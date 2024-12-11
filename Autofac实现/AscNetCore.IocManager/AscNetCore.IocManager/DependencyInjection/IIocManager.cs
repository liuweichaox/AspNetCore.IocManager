namespace AscNetCore.IocManager.DependencyInjection
{
    /// <summary>
    /// 管理器接口
    /// </summary>
    public interface IIocManager
    {
        TService GetInstance<TService>();
    }

}
