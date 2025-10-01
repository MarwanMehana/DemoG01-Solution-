using DemoG01.BusinessLogic.Services.Classes;
using DemoG01.BusinessLogic.Services.Interfaces;
using DemoG01.DataAccess.Data.Contexts;
using DemoG01.DataAccess.Models.IdentityModels;
using DemoG01.DataAccess.Repositories.Departments;
using DemoG01.DataAccess.Repositories.Employees;
using DemoG01.DataAccess.Repositories.UoW;
using DemoG03.BusinessLogic.Profiles;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoG01.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Add services to the container
            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });


            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //builder.Services.AddScoped<ApplicationDbContext>();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                //options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
                //options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings")["DefaultConnection"]);
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                options.UseLazyLoadingProxies();
            });
            builder.Services.AddScoped<IDepartmentRepository,DepartmentRepository>();
            builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();


            builder.Services.AddAutoMapper(m => m.AddProfile(new MappingProfiles()));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IAttachmentService, AttachmentService>();
			builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
			{
				options.Password.RequiredLength = 6;
				options.Password.RequireUppercase = true;
				options.Password.RequireLowercase = true;
				options.Password.RequireDigit = true;
				options.Password.RequireNonAlphanumeric = true;
				options.Password.RequiredUniqueChars = 3;

				options.User.RequireUniqueEmail = true;
				options.Lockout.AllowedForNewUsers = true;
				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(2);
				options.Lockout.MaxFailedAccessAttempts = 5;
			}).AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
			#endregion

			var app = builder.Build();
            #region Configure the HTTP request pipeline 
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
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
          
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=LogIn}/{id?}");
            #endregion
            app.Run(); 
        }
    }
}
