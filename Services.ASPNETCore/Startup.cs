using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using win10Core.Business.DataAccess;
using win10Core.Business.DataAccess.Interfaces;
using win10Core.Business.Engine;
using win10Core.Business.Engine.Interface;
using win10Core.Business.Model;
using win10Core.Business.NETCORE.Engine;
using win10Core.Business.NETCORE.Engine.Interface;

namespace Services.ASPNETCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) //, ILoggerFactory loggerFactory)
        {

            services.AddDbContext<DBContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IDBContext, DBContext>();
            services.AddTransient<IKidDataAccess, KidDataAccess>();
            services.AddTransient<ILogInfoDataAccess, LogInfoDataAccess>();
            services.AddTransient<ILogErrorDataAccess, LogErrorDataAccess>();
            services.AddTransient<IFamilyDataAccess, FamilyDataAccess>();
            services.AddTransient<IGiftDataAccess, GiftDataAccess>();
            services.AddTransient<IParentDataAccess, ParentDataAccess>();

            services.AddTransient<ILogEngine, LogEngine>();
            services.AddTransient<IKidEngine, KidEngine>();
            services.AddTransient<IParentEngine, ParentEngine>();
            services.AddTransient<IGiftEngine, GiftEngine>();
            services.AddTransient<ILogEngine, LogEngine>();
            services.AddTransient<IEmailEngine, EmailEngine>();
            services.AddSingleton<IEmailConfiguration>(new EmailConfiguration {
                SmtpServer = Configuration["AppSettings:SmtpServer"],
                SmtpPort = int.Parse(Configuration["AppSettings:SmtpPort"]),
                SmtpServerPassword = Configuration["AppSettings:SmtpServerPassword"],
                SmtpServerUserName = Configuration["AppSettings:SmtpServerUserName"]
            });
            //services.AddTransient<IEmailConfiguration, new EmailConfiguration { SmtpServer = Configuration.GetSection("AppSettings.SmtpPort") }>();

            services.AddMvc();
            services.AddRouting();
            services.AddAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action?}/{id?}");
                //routes.MapRoute(
                //    name: "DefaultApi",
                //    template: "api/{controller}/{action}/{id?}"
                //    );
            });

        }

    }
}
