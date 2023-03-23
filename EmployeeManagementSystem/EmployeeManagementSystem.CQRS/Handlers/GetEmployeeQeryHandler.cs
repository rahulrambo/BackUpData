using EmployeeManagementSystem.Core.Dtos;
using EmployeeManagementSystem.Core.Entities;
using EmployeeManagementSystem.CQRS.Queries;
using EmployeeManagementSystem.Infrastructure.Repositories;

namespace EmployeeManagementSystem.CQRS.Handlers
{

    internal class GetEmployeeQeryHandler : IRequestHandler<GetEmployeesQuery, Employee>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeQeryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository=employeeRepository;
        }

        public async Task<IEnumerable< EmployeeDto>>GetEmployeeAsync()
        {
            var result = await _employeeRepository.GetEmployeesAsync();
            return result;
        }

    }
}
