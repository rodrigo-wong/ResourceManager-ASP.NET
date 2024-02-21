using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using assignment1.Models;

namespace assignment1.Data
{
    public class assignment1Context : DbContext
    {
        public assignment1Context (DbContextOptions<assignment1Context> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<assignment1.Models.Game> Game { get; set; } = default!;
    }
}
