using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineGameSaleApp.Data;

namespace OnlineGameSaleApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<GameDbContext>(x => 
            {
                x.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]);
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.Configure<CookiePolicyOptions>(x=> 
            {
                x.CheckConsentNeeded = context => true;
                x.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDistributedMemoryCache();
            services.AddSession(x=> 
            {
                x.IdleTimeout = TimeSpan.FromSeconds(10);
                x.Cookie.HttpOnly = true;
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();                
            }


            app.UseStaticFiles();
            
            app.UseAuthentication();

            app.UseCookiePolicy();
            app.UseSession();

            app.UseMvc(x => {
                
                x.MapRoute(
                   name: "Default",
                   template: "{controller=Home}/{action=Index}/{id?}"
                );
                x.MapRoute(
                    name: "Admin",
                    template: "{area=exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });


        }
    }
}
