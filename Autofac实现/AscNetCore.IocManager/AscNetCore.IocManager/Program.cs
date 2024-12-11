using System.Reflection;
using AscNetCore.IocManager.DependencyInjection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// 配置 Autofac 容器
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{  
    containerBuilder.RegisterAssembly(Assembly.GetExecutingAssembly());
});

// 添加服务到默认 DI 容器（如 Controllers、视图支持等）
builder.Services.AddControllersWithViews();

// 构建应用
var app = builder.Build();

// 配置中间件管道
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseIocManager();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// 注册默认路由
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

// 启动应用
app.Run();