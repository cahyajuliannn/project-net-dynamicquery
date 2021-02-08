using LearnAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LearnAPI.Context
{
    public class MyContext:DbContext
    {
        public MyContext() : base("MyDbConnection")
        {

        }
        public DbSet<Department> departments { get; set; }
        public DbSet<Division> divisions { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Division>()
                .HasRequired<Department>(D => D.department)
                .WithMany(D => D.divisions).HasForeignKey<int>(De => De.DepartmenId);

            modelBuilder.Entity<Department>()
                .HasMany<Division>(D => D.divisions)
                .WithRequired(De => De.department)
                .HasForeignKey<int>(D => D.DepartmenId)
                .WillCascadeOnDelete();
        }
    }
}