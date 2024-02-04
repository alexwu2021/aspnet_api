using System;
using aspnetapp.Config;
using aspnetapp.DataAccessLayer.DBContexts;
using aspnetapp.DataAccessLayer.Repositories;
using aspnetapp.Provider.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MySql.EntityFrameworkCore.Infrastructure;
using MySql.EntityFrameworkCore;
//using MySql.EntityFrameworkCore.Properties;
//using MySql.EntityFrameworkCore.Extensions;

//using MySQL.EntityFrameworkCore.Extensions;
namespace aspnetapp
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            

            //AddScoped 针对每一次 HTTP 请求都会建立一个新的实例（视频P1）
            services.AddScoped<IPatientRepository, PatientRepository>();
            
            services.AddDbContext<PatientDbContext>(options =>
            {
                string connectionString = string.Empty;
                if (Configuration.GetConnectionString("devMySqlConnStr") != null)
                {
                    connectionString = Configuration.GetConnectionString("devMySqlConnStr");
                };
                Console.WriteLine("conn str found: " + connectionString);

                
                options.UseMySQL(connectionString,
                    b=>b.EnableRetryOnFailure(3)
                    );
                
            });
            
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseRouting();

            app.UseEndpoints(e => e.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"));
        }
    }
}
