namespace EmployeeManagementSystem.Core.Entities
{
    public partial class Holiday
    {
        public int HolidayId { get; set; }
        public string HolidayName { get; set; } = null!;
        public DateTime HolidayDate { get; set; }
    }
}
