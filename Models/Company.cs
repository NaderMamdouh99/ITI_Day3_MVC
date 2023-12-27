using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Labs_3.Models
{
    public partial class Company : DbContext
    {
        public Company()
            : base("name=Company")
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Instructor>()
                .HasMany(e => e.Departments)
                .WithOptional(e => e.Instructor)
                .HasForeignKey(e => e.Dept_Manager);
        }
    }
}
