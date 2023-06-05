using EmployeeAttendanceSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAttendanceSystem.Services.EmployeeServices
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployeeById(string employeeId);
        Task<Employee> UpdateEmployee(Employee employeeObj);
        Task<Employee> CreateEmployee(Employee employeeObj);
        Task<Employee> DeleteEmployee(string employeeId);
    }
}
