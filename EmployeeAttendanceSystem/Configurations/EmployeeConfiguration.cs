using EmployeeAttendanceSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAttendanceSystem.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.EmployeeId).IsRequired().HasMaxLength(50);
            builder.Property(e => e.EmployeeName).IsRequired().HasMaxLength(25);
            builder.Property(e => e.EmployeeGender).IsRequired().HasMaxLength(6);
            builder.Property(e => e.EmployeeContact).IsRequired().HasMaxLength(10);
            builder.Property(e => e.EmployeeUsername).IsRequired().HasMaxLength(20);
            builder.Property(e => e.EmployeePassword).IsRequired();
        }
    }
}
