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
        /// ������������ע��
        /// IoC���� inversion of control ���Ʒ�ת
        /// -ע�� ������
        /// -����ʵ��
        /// -ʵ������������
        /// ��������
        /// -Transient
        /// -Scoped
        /// -Singleton
        /// 
        /// �ŵ�
        /// ���û��ǿ����
        /// -���ڵ�Ԫ����
        /// ����Ҫ�˽����ķ�����
        /// ����Ҫ������������������
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc();

            services.AddControllersWithViews();

            //services.AddControllers();

            //����IClock�ӿ� ���� ChinaClock����
            //services.AddSingleton<IClock, ChinaClock>();
            services.AddSingleton<IClock, UtcClock>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// IApplicationBuilder ��Ӧ����
        /// ͨ������ע��ķ�ʽע��
        /// ע���ʹ�÷����Ӧ�ӿ�
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //���Ϊ����ģʽ
            if (env.IsDevelopment())
            {
                //�����������쳣���ø�ҳ�� �м��
                app.UseDeveloperExceptionPage();
            }
            //��Ӿ�̬�ļ� �м��
            app.UseStaticFiles();

            //ǿ���û�ʹ��httpsЭ��
            app.UseHttpsRedirection();

            //�����֤�м��
            app.UseAuthentication();

           //·���м��
            app.UseRouting();

            //�˵� endpoint 
            //�˵�Ϊ������http�����url�Ľ�β���֣��ò��ֻᱻ�м�����д���
            //  {controller}/{action}
            //  /hoem/index


            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});

                //MVCĬ������ ���������controller��Ĭ��Home id��ѡ
                //ע��·��ģ�� �� ͨ��
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                //ֱ����controller������ӱ�ǩ������/���� ����·������
                endpoints.MapControllers();
            });
        }
    }
}
