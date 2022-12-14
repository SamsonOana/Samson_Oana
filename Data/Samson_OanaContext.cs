using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Samson_Oana.Models;

namespace Samson_Oana.Data
{
    public class Samson_OanaContext : DbContext
    {
        public Samson_OanaContext (DbContextOptions<Samson_OanaContext> options)
            : base(options)
        {
        }

        public DbSet<Samson_Oana.Models.Book> Book { get; set; } = default!;

        public DbSet<Samson_Oana.Models.Publisher> Publisher { get; set; }
    }
}
