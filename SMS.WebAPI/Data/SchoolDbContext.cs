using Microsoft.EntityFrameworkCore;
using SMS.WebAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.WebAPI.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {

        }
        public DbSet<Course> Coureses { set; get; }
        public DbSet<Enrollement> Enrollements { set; get; }
        public DbSet<Student> Students { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasSequence<int>("Student_seq", schema: "dbo")
            //    .StartsAt(0)
            //    .IncrementsBy(1);

            //modelBuilder.Entity<Student>()
            //    .Property(o => o.Id)
            //    .HasDefaultValueSql("NEXT VALUE FOR dbo.Student_seq");
        }

    }
}
