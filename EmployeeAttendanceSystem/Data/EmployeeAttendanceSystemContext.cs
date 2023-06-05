using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeAttendanceSystem.Models;
using EmployeeAttendanceSystem.Configurations;

namespace EmployeeAttendanceSystem.Data
{
    public class EmployeeAttendanceSystemContext : DbContext
    {
        public EmployeeAttendanceSystemContext (DbContextOptions<EmployeeAttendanceSystemContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Attendance> Attendances { get; set; }

        public DbSet<Leave> Leaves { get; set; }

        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EmployeeConfiguration());
            builder.ApplyConfiguration(new AttendanceConfiguration());
            builder.ApplyConfiguration(new LeaveConfiguration());
            builder.ApplyConfiguration(new AdminConfiguration());
        }

        
    }
}
