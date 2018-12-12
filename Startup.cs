using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FieldP3_PersonalWebsite.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FieldP3_PersonalWebsite
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

            // Added: AddRoles<IdentityRole>() lambda expression
            // Alix Field 10.30.2018
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>().AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
           
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            // Calling CreateUsersAndRoles Method 
            // Alix Field 10.31.2018
            CreateUsersAndRoles(serviceProvider).Wait();
        }

        // --------------------------------------------------------------------------
        // Rober Garner: Creating Users and Roles
        // Professor at CNM
        // ---------------------------------------------------------------------------
        // Method: adds a role for admin, adds a user and assigns tha user to the admin role.
        private async Task CreateUsersAndRoles(IServiceProvider serviceProvider)
        {
            //Get reference to RoleManager and UserManager from serviceProvider through dependency injection
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            //Check if admin role exists and if not add it.
            var roleExist = await RoleManager.RoleExistsAsync("Admin");
            if (!roleExist)
            {
                //create the roles and seed them to the database: Question 1  
                await RoleManager.CreateAsync(new IdentityRole("Admin"));
            }

            //Check if admin user exists and if not add it
            IdentityUser user = await UserManager.FindByEmailAsync("admin@aserver.net");

            if (user == null)
            {
                user = new IdentityUser()
                {
                    UserName = "admin@aserver.net",
                    Email = "admin@aserver.net",
                };
                await UserManager.CreateAsync(user, "Password1!");

                //Add user to admin role
                await UserManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
