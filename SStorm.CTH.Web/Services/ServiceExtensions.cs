using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using SStorm.CTH.Web.Infrastructure;

namespace SStorm.CTH.Web
{
    public static class ClientNotificationServiceExtensions
    {
        public static void AddToastNotification(this IServiceCollection services)
        {
            var assembly = typeof(Components.NotificationViewComponent).GetTypeInfo().Assembly;
            //Create an EmbeddedFileProvider for that assembly
            var embeddedFileProvider = new EmbeddedFileProvider(assembly, "SStorm.CTH.Web");
            //Add the file provider to the Razor view engine
            services.Configure<MvcRazorRuntimeCompilationOptions>(options =>
            {
                options.FileProviders.Add(embeddedFileProvider);
                
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IClientNotification, ClientNotification>();
        }
    }
}
