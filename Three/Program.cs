using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Three
{
    public class Program
    {
        /// <summary>
        /// 控制台应用配置生成
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            
            CreateHostBuilder(args).Build().Run();
        }
        //createDefaultBuilder 时 IApplicationBuilder 注入
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
