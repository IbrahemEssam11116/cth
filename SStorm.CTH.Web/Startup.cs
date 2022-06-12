using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.Cookies;
using SStorm.CTH.Web.Infrastructure;
using SStorm.CTH.Web.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using SStorm.CTH.Web.Resources;
using System.Reflection;
using Microsoft.Extensions.Options;

namespace SStorm.CTH.Web
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
            System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder
                (Configuration.GetConnectionString("ConnectionString"));

            SStorm.CTH.BL.DataAccess.DataBase.ConnectionString = builder.ConnectionString;
            SStorm.CTH.BL.DataAccess.DataBase.SchemaName = "dbo";
            SStorm.CTH.BL.DataAccess.DataBase.DataBaseName = builder.InitialCatalog;

            SD.LLBLGen.Pro.ORMSupportClasses.RuntimeConfiguration.ConfigureDQE<SD.LLBLGen.Pro.DQE.SqlServer.SQLServerDQEConfiguration>(
                c => c.AddDbProviderFactory(typeof(System.Data.SqlClient.SqlClientFactory)));


            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();

            services.AddHttpContextAccessor();


            services.AddControllersWithViews()
                         .AddRazorRuntimeCompilation()
                         .AddViewLocalization()
                         .AddDataAnnotationsLocalization(options =>
                         {
                             options.DataAnnotationLocalizerProvider = (type, factory) =>
                             {
                                 var assemblyName = new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName);
                                 return factory.Create("SharedResource", assemblyName.Name);
                             };
                         });
            services.AddRazorPages();


            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IMailService, MailService>();
            services.AddSingleton<IFileService, FileService>();

            services.AddScoped<IAuthorizationHandler, CTH.Web.Infrastructure.PermissionAuthorizationHandler>();
            services.AddSingleton<IAuthorizationPolicyProvider, CTH.Web.Infrastructure.PermissionPolicyProvider>();


            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.Cookie.Name = "SSCTHData";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                options.LoginPath = "/Account/Login";
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });
            services.AddToastNotification();

            //aya
            services.AddSingleton<LocService>();
            services.AddLocalization(options => options.ResourcesPath = "Resources");



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            //app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    const int durationInSeconds = 60 * 60 * 24;
                    ctx.Context.Response.Headers[HeaderNames.CacheControl] =
                        "public,max-age=" + durationInSeconds;
                }
            });

            //var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            //app.UseRequestLocalization(locOptions.Value);

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });



            //app.UseStaticFiles();

        }
    }
}
