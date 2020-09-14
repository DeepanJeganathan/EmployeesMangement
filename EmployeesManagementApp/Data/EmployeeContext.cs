using EmployeesManagementApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManagementApp.Data
{
    public class EmployeeContext : IdentityDbContext

    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Workstation> Workstations { get; set; }
        public DbSet<Supervisor> Supervisors { get; set; }
        public DbSet<EmployeeWorkstation> EmployeeWorkstations { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Absence> Absences { get; set; }

        public DbSet<DisciplineStage> DisciplineStages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            base.OnModelCreating(modelBuilder);          

            modelBuilder.Entity<EmployeeWorkstation>()
                .HasKey(c => new { c.EmployeeNumber, c.WorkstationNumber });

           

        }
    }
}
