using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouseCannith.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Server.Kestrel;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
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
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();

            Configuration = builder.Build();
            HostingEnvironment = env;
        }

        public IHostingEnvironment HostingEnvironment { get; }
        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // Stuff added here is generally consumed in Controllers via automatic constructor injection
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(config => {
                var requireAuthenticationByDefaultPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();

                config.Filters.Add(new AuthorizeFilter(requireAuthenticationByDefaultPolicy));
            });

            services.AddAuthentication(
                SharedOptions => SharedOptions.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme);

            // There may be a better way to do this in the future - see
            // https://github.com/aspnet/KestrelHttpServer/issues/1334
            if (HostingEnvironment.IsDevelopment()) {
                services.Configure<KestrelServerOptions>(options => {
                    options.UseHttps("developmentHttpsCert.pfx", "insecure-development-cert-password");
                });
            }

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
