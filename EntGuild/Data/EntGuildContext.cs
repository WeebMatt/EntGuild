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
    }
}
