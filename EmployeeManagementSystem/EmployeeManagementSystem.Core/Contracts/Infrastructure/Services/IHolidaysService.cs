using EmployeeManagementSystem.Core.Dtos;
using EmployeeManagementSystem.Core.Entities;

namespace EmployeeManagementSystem.Core.Contracts.Infrastructure.Services
{
    public interface IHolidaysService
    {
        Task<Holiday> CreateAsync(Holiday holiday);
        Task<IEnumerable<HolidaysDto>> GetHolidaysAsync();
    }
}
