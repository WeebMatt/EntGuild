using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EntGuild.Models;

namespace EntGuild.Data
{
    public class EntGuildContext : DbContext
    {
        public EntGuildContext (DbContextOptions<EntGuildContext> options)
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
    }
}
