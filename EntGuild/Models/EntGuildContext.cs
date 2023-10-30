using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EntGuild.Models
{
    public class EntGuildContext : IdentityDbContext
    {
        public EntGuildContext(DbContextOptions<EntGuildContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Product> Product { get; set; } = default!;

        public DbSet<Genre> Genre { get; set; } = default!;

        public DbSet<Admin> Admin { get; set; } = default!;

        public DbSet<SubGenre> SubGenre { get; set; } = default!;

        public DbSet<Game_genre> Game_genre { get; set; } = default!;

        public DbSet<User> User { get; set; } = default!;

        public DbSet<Book_genre> Book_genre { get; set; } = default!;

        public DbSet<Movie_genre> Movie_genre { get; set; } = default!;
    }
}
