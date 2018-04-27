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

namespace Services.ASPNETCore.Docker
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

            services.AddDbContext<DBContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IDBContext, DBContext>();
            services.AddTransient<IKidDataAccess, KidDataAccess>();
            services.AddTransient<ILogEngine, LogEngine>();
            services.AddTransient<ILogInfoDataAccess, LogInfoDataAccess>();
            services.AddTransient<ILogErrorDataAccess, LogErrorDataAccess>();
            services.AddTransient<IFamilyDataAccess, FamilyDataAccess>();
            services.AddTransient<IGiftDataAccess, GiftDataAccess>();
            services.AddTransient<IParentDataAccess, ParentDataAccess>();

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

            // app.UseMvc();

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


            //var trackPackageRouteHandler = new RouteHandler(context =>
            //{
            //    var routeValues = context.GetRouteData().Values;
            //    return context.Response.WriteAsync(
            //        $"Hello! Route values: {string.Join(", ", routeValues)}");
            //});

            //var routeBuilder = new RouteBuilder(app, trackPackageRouteHandler);

            //routeBuilder.MapRoute(
            //    "Track Package Route",
            //    "package/{operation:regex(^(track|create|detonate)$)}/{id:int}");

            //routeBuilder.MapGet("hello/{name}", context =>
            //{
            //    var name = context.GetRouteValue("name");
            //    // This is the route handler when HTTP GET "hello/<anything>"  matches
            //    // To match HTTP GET "hello/<anything>/<anything>,
            //    // use routeBuilder.MapGet("hello/{*name}"
            //    return context.Response.WriteAsync($"Hi, {name}!");
            //});

            //var routes = routeBuilder.Build();
            //app.UseRouter(routes);
        }
    }
}
