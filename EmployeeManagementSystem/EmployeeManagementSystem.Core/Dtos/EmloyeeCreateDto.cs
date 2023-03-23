﻿namespace EmployeeManagementSystem.Core.Dtos
{
    public class EmloyeeCreateDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string EmailId { get; set; } = null!;
        public string Contact { get; set; } = null!;
        public string Address { get; set; } = null!;
        public decimal Salary { get; set; }
        public int? DepartmentId { get; set; }
        public int? RoleId { get; set; }


    }
}
