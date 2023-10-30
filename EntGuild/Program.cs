using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyApplication.Data;
using Microsoft.AspNetCore.Identity;
public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<EntGuildContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("EntGuildContextConnection") ?? throw new InvalidOperationException("Connection string 'EntGuildContext' not found.")));

        builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<EntGuildContext>();

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        builder.Services.AddRazorPages();

        builder.Services.AddDistributedMemoryCache();
        builder.Services.AddSession(options =>
        {
            options.Cookie.Name = "EntGuild.Session";
            options.IdleTimeout = TimeSpan.FromMinutes(5);
        }
        );

        var app = builder.Build();

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

        app.UseSession();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
        });

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        using (var scope = app.Services.CreateScope())
        {
            var roleMgr = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var Roles = new[] 
            { 
                "Employees",
                "Customers",
                "Admin" 
            };

            foreach (var role in Roles)
            {
                if (!await roleMgr.RoleExistsAsync(role))
                    await roleMgr.CreateAsync(new IdentityRole(role));

            }
        }

        using (var scope = app.Services.CreateScope())
        {
            var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            string emailAdmin = "administrator@example.com";
            string passwordAdmin = "Pa$$w0rd";

            if (await userMgr.FindByEmailAsync(emailAdmin) == null)
            {
                var user = new IdentityUser();
                user.UserName = emailAdmin;
                user.Email = passwordAdmin;

                await userMgr.CreateAsync(user, passwordAdmin);

                await userMgr.AddToRoleAsync(user, "Admin");

            }

            string email = "customer@example.com";
            string password = "P@ssword1";

            if (await userMgr.FindByEmailAsync(email) == null)
            {
                var user = new IdentityUser();
                user.UserName = email;
                user.Email = password;

                await userMgr.CreateAsync(user, password);

                await userMgr.AddToRoleAsync(user, "Customers");

            }

            string emailEmployee = "employee@example.com";
            string passwordEmployee = "Passw0rd!";

            if (await userMgr.FindByEmailAsync(emailEmployee) == null)
            {
                var user = new IdentityUser();
                user.UserName = emailEmployee;
                user.Email = passwordEmployee;

                await userMgr.CreateAsync(user, passwordEmployee);

                await userMgr.AddToRoleAsync(user, "Employees");

            }


        }

        app.Run();
    }
}