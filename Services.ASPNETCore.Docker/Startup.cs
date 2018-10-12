using System;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Services.ASPNETCore.Docker.Model;
using Swashbuckle.AspNetCore.Swagger;
using win10Core.Business.Standard.DataAccess;
using win10Core.Business.Standard.DataAccess.Interface;
using win10Core.Business.Standard.Engine;
using win10Core.Business.Standard.Engine.Interface;
using win10Core.Business.Standard.Model;

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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });

            services.AddMvc();
            // Configure Identity
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                // Cookie settings
                //options.Cookies.ApplicationCookie.ExpireTimeSpan = TimeSpan.FromDays(150);
                //options.Cookies.ApplicationCookie.LoginPath = "/Account/Login";
                // User settings
                options.User.RequireUniqueEmail = true;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "My API",
                    Description = "My First ASP.NET Core Web API",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "Talking Dotnet", Email = "contact@talkingdotnet.com", Url = "www.talkingdotnet.com" }
                });
            });
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
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                //routes.MapRoute(
                //    name: "DefaultApi",
                //    template: "api/{controller}/{action}/{id?}"
                //    );
            });
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
            }

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
