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
        public virtual DbSet<Battle> Battles { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.LogTo(Console.WriteLine);

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<SamuraiBattle>().HasKey(x => new { x.SamuraiId, x.BattleRefId });
            modelbuilder.Entity<Battle>().Property(b => b.StartDate).HasColumnType("Date");
            modelbuilder.Entity<Battle>().Property(b => b.EndDate).HasColumnType("Date");

            //Shadow properties for quote entity
            modelbuilder.Entity<Quote>().Property<DateTime>("LastModifiedOn");

            //If you name your foreign keys correctly or notify ef core about the discrepancy
            // between the primary and foreign key names in the data annotation, you don't need the following
            modelbuilder.Entity<SamuraiBattle>()
                .HasOne(sb => sb.Samurai)
                .WithMany(sb => sb.SamuraiBattles)
                .HasForeignKey(sb => sb.SamuraiId);
            modelbuilder.Entity<SamuraiBattle>()
                .HasOne(sb => sb.Battle)
                .WithMany(sb => sb.SamuraiBattles)
                .HasForeignKey(sb => sb.BattleRefId);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            var modifiedQuoteEntries = ChangeTracker
                .Entries<Quote>()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);
            
            foreach(var item in modifiedQuoteEntries)
            {
                item.Property("LastModifiedOn").CurrentValue = DateTime.Now;
            }
            
            //foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            //{
            //    if (entry.Entity.GetType().Name == nameof(Quote))  //GetType().Name = "Quotes", btw..
            //    {
            //        entry.Property("LastModifiedOn").CurrentValue = timestamp;
            //    }
            //}

            return base.SaveChanges();
        }

    }
}
