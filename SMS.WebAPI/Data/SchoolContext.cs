using Microsoft.EntityFrameworkCore;
using SMS.WebAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.WebAPI.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {

        }
        public DbSet<Course> Coureses { set; get; }
        public DbSet<Enrollement> Enrollements { set; get; }
        public DbSet<Student> Students { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollement>().ToTable("Enrollement");
            modelBuilder.Entity<Student>().ToTable("Student");
        }

    }
}
