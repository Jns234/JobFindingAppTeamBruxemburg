using JobFindingAppTeamBruxemburg.Data;
using JobFindingAppTeamBruxemburg.Repositories;
using JobFindingAppTeamBruxemburg.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace JobFindingAppTeamBruxemburg
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
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddMvc();
            services.AddAutoMapper(typeof(Program).Assembly);
            services.AddControllersWithViews();

            services.AddTransient<ITagService, TagService>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IEmployerService, EmployerService>();
            services.AddScoped<IEmployerRepository, EmployerRepository>();


            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();




            services.AddSingleton<IConfiguration>(Configuration);

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        private void EnsureDatabase(IApplicationBuilder app)
        {
            var serviceScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            using (var serviceScope = serviceScopeFactory.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                dbContext.Database.EnsureCreated();

                var uow = serviceScope.ServiceProvider.GetService<IUnitOfWork>();

                if (dbContext.Tags.Count() == 0)
                {

                    var tag = new Tag
                    {
                        Title = "This is a tag"
                    };
                    new Tag
                    {
                        Title = "Another Tag"
                    };
                    

                    dbContext.Tags.Add(tag);


                    dbContext.SaveChanges();

                }
            }
        }
    }
}
