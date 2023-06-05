using EmployeeAttendanceSystem.Data;
using EmployeeAttendanceSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAttendanceSystem.Services.AttendanceServices
{
    public class AttendanceService : IAttendanceService
    {
        private readonly EmployeeAttendanceSystemContext _context;
 
        public AttendanceService(EmployeeAttendanceSystemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Attendance>> GetAttendances()
        {
            return await _context.Attendances.ToListAsync();
        }
        public async Task<Attendance> GetAttendanceById(string attendanceId)
        {
            var result =  await _context.Attendances.FirstOrDefaultAsync(a => a.AttendanceId == attendanceId);
            return result;
        }

        public async Task<Attendance> CreateAttendance(Attendance attendanceObj)
        {
            var result = await _context.Attendances.AddAsync(attendanceObj);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Attendance> DeleteAttendance(string attendanceId)
        {
            var result = await _context.Attendances.FirstOrDefaultAsync(a => a.AttendanceId == attendanceId);
            if (result != null)
            {
                _context.Attendances.Remove(result);
                await _context.SaveChangesAsync();
            }
            return result;
        }
        
        public async Task<Attendance> UpdateAttendance(Attendance attendanceObj)
        {
            var result = await _context.Attendances.FirstOrDefaultAsync(a => a.AttendanceId == attendanceObj.AttendanceId);

            if (result != null)
            {
                if(attendanceObj.AttendanceStatus != null && attendanceObj.AttendanceStatus != "")
				{
                    result.AttendanceStatus = attendanceObj.AttendanceStatus;
                }
                
                result.AttendanceDate = attendanceObj.AttendanceDate;
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
