using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyApplication.Data;

public class EntGuildContext : IdentityDbContext<IdentityUser>
{
    public EntGuildContext(DbContextOptions<EntGuildContext> options)
    : base(options)
    {
    }

    public DbSet<EntGuild.Models.Product> Product { get; set; } = default!;

    public DbSet<EntGuild.Models.Genre> Genre { get; set; } = default!;

    public DbSet<EntGuild.Models.Admin> Admin { get; set; } = default!;

    public DbSet<EntGuild.Models.SubGenre> SubGenre { get; set; } = default!;

    public DbSet<EntGuild.Models.Game_genre> Game_genre { get; set; } = default!;

    public DbSet<EntGuild.Models.Order> Order { get; set; } = default!;

    public DbSet<EntGuild.Models.User> User { get; set; } = default!;

    public DbSet<EntGuild.Models.Book_genre> Book_genre { get; set; } = default!;

    public DbSet<EntGuild.Models.Movie_genre> Movie_genre { get; set; } = default!;
protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
