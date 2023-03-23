using Dapper;
using EmployeeManagementSystem.Core.Contracts.Infrastructure.Respositories;
using EmployeeManagementSystem.Core.Dtos;
using EmployeeManagementSystem.Core.Entities;
using System.Data;

namespace EmployeeManagementSystem.Infrastructure.Repositories
{
    public class HolidayRepository : IHolidayRepository
    {
        private readonly EmployeemanagementDbContext _employeeManagementDataDbContext;
        private readonly IDbConnection _dapperConnection;
        public HolidayRepository(EmployeemanagementDbContext employeemanagementDbContext , IDbConnection dbConnection)
        {
            _employeeManagementDataDbContext = employeemanagementDbContext;
            _dapperConnection = dbConnection;
        }
        public async Task<Holiday> CreateAsync(Holiday holiday)
        {
            await _employeeManagementDataDbContext.Holidays .AddAsync(holiday);
            await _employeeManagementDataDbContext.SaveChangesAsync();
            return holiday;
        }

        public async Task<IEnumerable<HolidaysDto>> GetHolidaysAsync()
        {
            var getHolidays = "select * from Holidays";
            var result = await _dapperConnection.QueryAsync<HolidaysDto>(getHolidays);
            return result;
        }
    }
}
