using EmployeeManagementSystem.Core.Dtos;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.CQRS.Queries
{
    public class GetEmployeesQuery : IRequest<IEnumerable<EmployeeDto>>
    {

    }
}
