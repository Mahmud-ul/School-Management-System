using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace schoolApp.Models
{
    public class ConnectionStringClass : DbContext
    {
        public ConnectionStringClass(DbContextOptions<ConnectionStringClass> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Department>().HasIndex(d => d.Name).IsUnique();
            model.Entity<Student>().HasIndex(s => s.Email).IsUnique();
            model.Entity<Course>().HasIndex(c => c.Name).IsUnique();
        }
    }
}
