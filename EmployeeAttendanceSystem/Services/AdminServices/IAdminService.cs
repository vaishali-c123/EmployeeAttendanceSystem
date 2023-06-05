using EmployeeAttendanceSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAttendanceSystem.Services.AdminServices
{
    public interface IAdminService
    {
        Task<IEnumerable<Admin>> GetAdmins();
        Task<Admin> GetAdminById(string adminId);
        Task<Admin> UpdateAdmin(Admin adminObj);
        Task<Admin> CreateAdmin(Admin adminObj);
        Task<Admin> DeleteAdmin(string adminId);
    }
}
