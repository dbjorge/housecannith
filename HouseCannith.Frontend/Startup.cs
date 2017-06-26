using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouseCannith.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace HouseCannith_Frontend
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // How to connect to the comprendium database for local testing:
                //  1) Add your dev box's IP to the firewall rules at portal.azure.com
                //  2) Right click on the HouseCannith.WebApp project, Manage User Secrets, and add an entry as follows (filling in the password):
                //       "COMPRENDIUM_DATABASE_CONNECTION_STRING": "Server=tcp:comprendium.database.windows.net,1433;Initial Catalog=comprendium;Persist Security Info=False;User ID=ComprendiumDev;Password=PASSWORD_FROM_KEYPASS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
                //
                // For more details on using the user secret store see https://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // Stuff added here is generally available in Controllers via automatic dependency injection
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            services.AddAuthentication(
                SharedOptions => SharedOptions.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme);

            var comprendiumDbConnectionString = Configuration["COMPRENDIUM_DATABASE_CONNECTION_STRING"];

            services.AddDbContext<ComprendiumDbContext>(options => options.UseSqlServer(comprendiumDbConnectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions {
                    HotModuleReplacement = true,
                    ReactHotModuleReplacement = true
                });
                app.UseBrowserLink(); // Maybe wrong?
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseHttpToHttpsRedirect();

            app.UseStaticFiles();

            app.UseCookieAuthentication();

            app.UseOpenIdConnectAuthentication(new OpenIdConnectOptions
            {
                ClientId = Configuration["Authentication:AzureAd:ClientId"],
                Authority = Configuration["Authentication:AzureAd:AADInstance"] + Configuration["Authentication:AzureAd:TenantId"],
                CallbackPath = Configuration["Authentication:AzureAd:CallbackPath"]
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }

    public static class IApplicationBuilderHttpsExtensions
    {
        public static void UseHttpToHttpsRedirect(this IApplicationBuilder app)
        {
            app.UseWhen(
                context => !context.Request.IsHttps,
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
                httpApp => httpApp.Use(async (context, next) =>
                {
                    var httpsUrl = "https://" + context.Request.Host + context.Request.Path;
                    context.Response.Redirect(httpsUrl);
                }));
#pragma warning restore CS1998
        }
    }
}
