using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Three.Service;

namespace Three
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /// <summary>
        /// 负责配置依赖注入
        /// IoC容器 inversion of control 控制反转
        /// -注册 （服务）
        /// -请求实例
        /// -实例的生命周期
        /// 生命周期
        /// -Transient
        /// -Scoped
        /// -Singleton
        /// 
        /// 优点
        /// 解耦，没有强依赖
        /// -利于单元测试
        /// 不需要了解具体的服务类
        /// 不需要管理服务类的生命周期
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc();

            services.AddControllersWithViews();

            //services.AddControllers();

            //调用IClock接口 返回 ChinaClock对象
            //services.AddSingleton<IClock, ChinaClock>();
            services.AddSingleton<IClock, UtcClock>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// IApplicationBuilder 对应服务
        /// 通过依赖注入的方式注入
        /// 注入后使用服务对应接口
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //如果为开发模式
            if (env.IsDevelopment())
            {
                //如果程序出现异常调用该页面 中间件
                app.UseDeveloperExceptionPage();
            }
            //添加静态文件 中间件
            app.UseStaticFiles();

            //强制用户使用https协议
            app.UseHttpsRedirection();

            //身份认证中间件
            app.UseAuthentication();

           //路由中间件
            app.UseRouting();

            //端点 endpoint 
            //端点为进来的http请求的url的结尾部分，该部分会被中间件进行处理
            //  {controller}/{action}
            //  /hoem/index


            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});

                //MVC默认配置 如果不输入controller则默认Home id可选
                //注册路由模板 或 通过
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                //直接在controller类上添加标签或属性/特性 进行路由配置
                endpoints.MapControllers();
            });
        }
    }
}
