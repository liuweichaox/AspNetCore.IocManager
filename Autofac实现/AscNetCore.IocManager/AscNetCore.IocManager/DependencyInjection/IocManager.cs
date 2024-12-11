using System;
using Autofac;

namespace AscNetCore.IocManager.DependencyInjection
{
    /// <summary>
    /// <see cref="IIocManager"/>管理器实现类
    /// </summary>
    public class IocManager(ILifetimeScope autofacContainer) : IIocManager, ISingletonDependency
    {
        private readonly ILifetimeScope _autofacContainer = autofacContainer ?? throw new ArgumentNullException(nameof(autofacContainer));
        
        public static IocManager Instance { get; private set; }
        
        // 构造函数（支持动态注入）

        // 静态初始化方法（支持静态获取）
        public static void Initialize(ILifetimeScope autofacContainer)
        {
            if (Instance != null)
                throw new InvalidOperationException("IocManager has already been initialized.");
            Instance = new IocManager(autofacContainer);
        }
        
        /// <summary>
        /// 动态获取服务
        /// </summary>
        public TService GetInstance<TService>()
        {
            if (Instance != null)
            {
                return Instance._autofacContainer.Resolve<TService>(); 
            }
            return _autofacContainer.Resolve<TService>();
        }
    }

}
