using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Dados;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Session;
using Util;
using Util.Language;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Sicle.Web.Util;

namespace Web
{
    public class Startup
    {
        public static IHostingEnvironment CurrentEnvironment { get; set; }
             

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("pt-BR");
                options.SupportedCultures = new List<CultureInfo> { new CultureInfo("en-US"), new CultureInfo("pt-BR") };
            });

            services.AddMvc(options =>
                {
                    //options.ModelBinderProviders.Insert(0, new DateTimeModelBinderProvider());
                }
            ).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseOracle(Configuration.GetConnectionString("SicleDev"), b =>
                    b.UseOracleSQLCompatibility("11")
                );
                //comentar para executar migrations
                if (Startup.CurrentEnvironment.IsDevelopment())
                {
                   options.UseLoggerFactory(AppLogger.Factory).EnableSensitiveDataLogging();
                }
            });

            services.AddDirectoryBrowser();

            //services.AddControllersWithViews().AddRazorRuntimeCompilation();           
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.Cookie.Name = "Sicle.Session";
                //options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });       

            services.AddHttpContextAccessor();      
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            Startup.CurrentEnvironment = env;           

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\res")),
                RequestPath = "/res"
            });

            LanguageManager.Instance().AddLanguage(new CultureInfo("pt-BR"), "wwwroot/res/pt-BR.res");

            //app.UseRouting();
            //app.UseAuthorization();
            ConfigureSession(app);
            ConfigureRoutes(app);
        }

        private void ConfigureSession(IApplicationBuilder app)
        {
            app.UseSession();
            SessionVariables.Configure(app.ApplicationServices.GetRequiredService<IHttpContextAccessor>());
        }

        private void ConfigureRoutes(IApplicationBuilder app)
        {
            app.UseMvc(routes =>
            {
                routes.MapAreaRoute(
                    name: "AreaAcessos",
                    areaName: "Acessos",
                    template: "Acessos/{controller=Home}/{action=Index}/{id?}");

                routes.MapAreaRoute(
                    name: "AreaContratos",
                    areaName: "Contratos",
                    template: "Contratos/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
