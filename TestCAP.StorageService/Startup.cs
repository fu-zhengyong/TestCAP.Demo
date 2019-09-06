using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TestCAP.Events;
using TestCAP.StorageService.Models.Database;
using TestCAP.StorageService.Services;

namespace TestCAP.StorageService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // EF DbContext
            services.AddDbContext<StorageDbContext>();

            // Dapper-ConnString
            services.AddSingleton("Server=.;Database=Test_Order;Uid=sa;Password=fxy");

            // Subscriber
            services.AddTransient<IOrderSubscriberService, OrderSubscriberService>();

            // CAP
            services.AddCap(x =>
            {
                x.UseEntityFramework<StorageDbContext>(); // EF

                x.UseSqlServer("Server=.;Database=Test_Order;Uid=sa;Password=fxy"); // SQL Server

                x.UseRabbitMQ(cfg =>
                {
                    cfg.HostName = "192.168.0.92";
                    cfg.VirtualHost = "FXYHOST";
                    cfg.Port = 5672;//15672 web界面管理端口  5672 client通讯端口
                    cfg.UserName = "admin";
                    cfg.Password = "admin";
                }); // RabbitMQ

                // Below settings is just for demo
                x.FailedRetryCount = 2;
                x.FailedRetryInterval = 5;
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
