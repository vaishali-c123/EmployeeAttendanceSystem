using EmployeeAttendanceSystem.Data;
using EmployeeAttendanceSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAttendanceSystem.Services.EmployeeServices
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeAttendanceSystemContext _context;
		private readonly IConfiguration _configuration;

		public EmployeeService(EmployeeAttendanceSystemContext context,IConfiguration configuration)
        {
            _context = context;
			this._configuration = configuration;
		}
        private void CreatePasswordHash(string password, out string passwordHash)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
				
				hmac.Key = System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("Encryption:SHAKEY").Value);
                passwordHash = BitConverter.ToString(hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)));
            }
        }


        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(string employeeId)
        {
            return await _context.Employees.FirstOrDefaultAsync(a => a.EmployeeId == employeeId);
        }

        public async Task<Employee> CreateEmployee(Employee employeeObj)
        {
			string password;
			this.CreatePasswordHash(employeeObj.EmployeePassword, out password);
            employeeObj.EmployeePassword = password;
            var result = await _context.Employees.AddAsync(employeeObj);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> DeleteEmployee(string employeeId)
        {
            var result = await _context.Employees.FirstOrDefaultAsync(a => a.EmployeeId == employeeId);
            if (result != null)
            {
                _context.Employees.Remove(result);
                await _context.SaveChangesAsync();
            }
            return result;
        }

        public async Task<Employee> UpdateEmployee(Employee employeeObj)
        {
            var result = await _context.Employees.FirstOrDefaultAsync(a => a.EmployeeId == employeeObj.EmployeeId);

            if (result != null)
            {
                if (employeeObj.EmployeeEmail != null && employeeObj.EmployeeEmail != "")
				{
                    result.EmployeeEmail = employeeObj.EmployeeEmail;
                }

                if (employeeObj.EmployeeContact > 0 && employeeObj.EmployeeContact != 0)
                {
                    result.EmployeeContact = employeeObj.EmployeeContact;
                }
                if (employeeObj.EmployeePassword != null && employeeObj.EmployeePassword != "")
                {
                    
                    this.CreatePasswordHash(employeeObj.EmployeePassword, out var tempPasswordHash);
                    result.EmployeePassword = tempPasswordHash;
                }

                
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
