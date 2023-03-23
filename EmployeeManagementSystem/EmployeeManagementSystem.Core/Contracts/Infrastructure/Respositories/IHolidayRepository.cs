using EmployeeManagementSystem.Core.Dtos;
using EmployeeManagementSystem.Core.Entities;

namespace EmployeeManagementSystem.Core.Contracts.Infrastructure.Respositories
{
    public interface IHolidayRepository
    {
        Task<Holiday> CreateAsync(Holiday department);
        Task<IEnumerable<HolidaysDto>> GetHolidaysAsync();
    }
}
