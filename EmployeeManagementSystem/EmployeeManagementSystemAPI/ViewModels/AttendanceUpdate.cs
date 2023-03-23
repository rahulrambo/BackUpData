using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystemAPI.ViewModels
{
    public class AttendanceUpdate
    {
        [Required]
        public DateTime? TimeOut { get; set; }
        [Required]
        public string? EffectiveHours { get; set; }
    }
}
