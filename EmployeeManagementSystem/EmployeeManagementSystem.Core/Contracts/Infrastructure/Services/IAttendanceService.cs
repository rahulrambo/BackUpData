using EmployeeManagementSystem.Core.Dtos;
using EmployeeManagementSystem.Core.Entities;

namespace EmployeeManagementSystem.Core.Contracts.Infrastructure.Services
{
    public interface IAttendanceService
    {
         Task<Attendance> CreateAsync(Attendance attendance);
         Task<IEnumerable<AttendanceDto>> GetAttendanceAsync();
         Task<IEnumerable<EmployeeAttendanceDto>> GetEmployeeAttendanceById(int empId);
         Task<Attendance> UpdateAsync(int attendanceId, Attendance attendance);

         Task<IEnumerable<EmployeeAttendanceWithLeavesDto>> EmployeeAttendanceWithLeaves(int empId);
    }
}
