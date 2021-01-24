using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using dershane.business.Abstract;
using dershane.business.Concrete;
using dershane.data.Abstract;
using dershane.data.Concrete.EfCore;
using dershane.webui.EmailServices;
using dershane.webui.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace dershane.webui
{
    public class Startup
    {
        private IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options => options.UseSqlite("Data Source=dershaneDb"));
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = true;

                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.AllowedForNewUsers = true;

                // options.User.AllowedUserNameCharacters = "";
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/account/login";
                options.LogoutPath = "/account/logout";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".Dershane.Security.Cookie",
                    SameSite = SameSiteMode.Strict
                };

            });

            services.AddScoped<IBolumRepository, EfCoreBolumRepository>();
            services.AddScoped<IOgrenciRepository, EfCoreOgrenciRepository>();

            services.AddScoped<IOgrenciService, OgrenciManager>();
            services.AddScoped<IBolumService, BolumManager>();

            services.AddScoped<IEmailSender, SmtpEmailSender>(i => new SmtpEmailSender(_configuration["EmailSender:Host"],
             _configuration.GetValue<int>("EmailSender:Port"),
             _configuration.GetValue<bool>("EmailSender:EnableSSL"),
             _configuration["EmailSender:UserName"],
             _configuration["EmailSender:Password"]
             ));

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IConfiguration configuration,UserManager<User> userManager,RoleManager<IdentityRole> roleManager)
        {
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
                RequestPath = "/modules"
            });




            if (env.IsDevelopment())
            {
                SeedDatabase.Seed();
                app.UseDeveloperExceptionPage();
            }
            
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "adminuseredit",
                    pattern: "admin/user/{id?}",
                    defaults: new { controller = "Admin", action = "UserEdit" }
                );
                endpoints.MapControllerRoute(
                    name: "adminrusers",
                    pattern: "admin/user/list",
                    defaults: new { controller = "Admin", action = "UserList" }
                );
                endpoints.MapControllerRoute(
                    name: "adminroles",
                    pattern: "admin/role/list",
                    defaults: new { controller = "Admin", action = "RoleList" }
                );
                endpoints.MapControllerRoute(
                    name: "adminrolecreate",
                    pattern: "admin/role/create",
                    defaults: new { controller = "Admin", action = "RoleCreate" }
                );
                endpoints.MapControllerRoute(
                    name: "adminroleedit",
                    pattern: "admin/role/{id?}",
                    defaults: new { controller = "Admin", action = "RoleEdit" }
                );
                endpoints.MapControllerRoute(
                    name: "adminogrenciler",
                    pattern: "admin/ogrenciler",
                    defaults: new { controller = "Admin", action = "OgrenciList" }
                );
                endpoints.MapControllerRoute(
                    name: "adminogrencicreate",
                    pattern: "admin/ogrenciler/create",
                    defaults: new { controller = "Admin", action = "OgrenciCreate" }
                );
                endpoints.MapControllerRoute(
                    name: "adminogrenciedit",
                    pattern: "admin/ogrenciler/{id?}",
                    defaults: new { controller = "Admin", action = "OgrenciEdit" }
                );
                endpoints.MapControllerRoute(
                    name: "adminbolumler",
                    pattern: "admin/bolumler",
                    defaults: new { controller = "Admin", action = "BolumList" }
                );
                endpoints.MapControllerRoute(
                    name: "adminbolumcreate",
                    pattern: "admin/bolumler/create",
                    defaults: new { controller = "Admin", action = "BolumCreate" }
                );
                endpoints.MapControllerRoute(
                    name: "adminbolumedit",
                    pattern: "admin/bolumler/{id?}",
                    defaults: new { controller = "Admin", action = "BolumEdit" }
                );
                endpoints.MapControllerRoute(
                    name: "search",
                    pattern: "search/{bolum?}",
                    defaults: new { controller = "Genel", action = "search" }
                );
                endpoints.MapControllerRoute(
                   name: "ogrenciler",
                   pattern: "ogrenciler/{bolum?}",
                   defaults: new { controller = "Genel", action = "list" }
               );
                endpoints.MapControllerRoute(
                    name: "ogrencilerdetails",
                    pattern: "{url}",
                    defaults: new { controller = "Genel", action = "details" }
                );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            });
            
            SeedIdentity.Seed(userManager,roleManager,configuration).Wait();
        }
    }
}
