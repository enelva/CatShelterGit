using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatShelter.Models
{
    public class CatShelterContext : DbContext
    {
        public DbSet<Cat> Cats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cat>().ToTable("Table");
        }
    }

    public class Cat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Kindness { get; set; }
        public double WeightKG { get; set; }
    }
}
