using LibraryManagement.Controllers;
using LibraryManagement.Data;
using LibraryManagement.Models;
using LibraryManagement.Repository.Interfaces;
using LibraryManagement.Repository.Repositories;
using LibraryManagement.Service.Interface;
using LibraryManagement.Service.Services;
using LibraryManagement.Utils.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement
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
            services.AddIdentity<User, IdentityRole<int>>(options => {
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = true;
                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = new PathString("/Identity/Account/Login");
                options.AccessDeniedPath = new PathString("/Identity/Account/AccessDenied");
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IRequestRepository, RequestRepository>();
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<ISubsidiaryRepository, SubsidiaryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPurchaseRepository, PurchaseRepository>();

            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<ISubsidiaryService, SubsidiaryService>();
            services.AddScoped<IStockService, StockService>();
            services.AddScoped<IStatusService, StatusService>();

            services.AddScoped<IPaymentService<int>, MockupPaymentService>();
            services.AddScoped<IPurchaseService<int>, MockupPurchaseService>();

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStatusCodePages();
            //app.UseStatusCodePagesWithRedirects("/Home/Error");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Book}/{action=Index}");
                endpoints.MapRazorPages();
            });
        }
    }
}
