using Microsoft.EntityFrameworkCore;
using SamuraiAppCW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamuraiAppCW.Data
{
    public class SamuraiContext: DbContext
    {
        public SamuraiContext(DbContextOptions<SamuraiContext> options) : base(options) 
        {}

        public virtual DbSet<Samurai> Samurais { get; set; }
        public virtual DbSet<Quote> Quotes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.LogTo(Console.WriteLine);

    }
}
