using EmployeeManagementSystem.Core.Contracts.Infrastructure.Respositories;
using EmployeeManagementSystem.Core.Contracts.Infrastructure.Services;
using EmployeeManagementSystem.Core.Dtos;
using EmployeeManagementSystem.Core.Entities;

namespace EmployeeManagementSystem.Infrastructure.Services
{
    public class HolidayServices : IHolidaysService
    {
        private readonly IHolidayRepository _holidayRepository;

        public HolidayServices(IHolidayRepository holidayRepository )
        {
            _holidayRepository = holidayRepository;
        }
        public async Task<Holiday> CreateAsync(Holiday holiday)
        {
            var data = await _holidayRepository.CreateAsync(holiday);
            return data;
        }

        public async Task<IEnumerable<HolidaysDto>> GetHolidaysAsync()
        {
            var holidaysData = await _holidayRepository.GetHolidaysAsync();
            return holidaysData;
        }
    }
}
