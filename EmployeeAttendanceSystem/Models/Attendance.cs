using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAttendanceSystem.Models
{
    public class Attendance
    {
        [Key]
        public string AttendanceId { get; set; }

        public string AttendanceStatus { get; set; }

        public DateTime AttendanceDate { get; set; }

        //Foreign Key
        [ForeignKey("EmployeeId")]
        public string EmployeeId { get; set; }
        public virtual Employee Employees { get; set; }
    }
}