using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAttendanceSystem.Models
{
    public class Employee
    {
        [Key]
        public string EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public string EmployeeGender { get; set; }

        public string EmployeeEmail { get; set; }
       
        public double EmployeeContact { get; set; }
              
        public string EmployeeUsername { get; set; }

        public string EmployeePassword { get; set; }

		public EmployeeType EmployeeType { get; set; }

	}
}