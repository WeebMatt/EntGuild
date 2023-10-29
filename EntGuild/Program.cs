using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EntGuild.Data;
using Microsoft.AspNetCore.Identity;
public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<EntGuildContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("EntGuildContext") ?? throw new InvalidOperationException("Connection string 'EntGuildContext' not found.")));




        builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<EntGuildContext>();
        // Add services to the container.
        builder.Services.AddControllersWithViews();

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

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        using (var scope = app.Services.CreateScope())
        {
            var roleMgr = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var Roles = new[] { "Employees", "Customers", "Admin" };

            foreach (var role in Roles)
            {
                if (!await roleMgr.RoleExistsAsync(role)
                    //await roleMgr.CreateAsync(new IdentityRole(role));

            }
        }
        app.Run();
    }
}