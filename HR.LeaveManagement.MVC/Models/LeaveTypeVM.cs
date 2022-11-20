using System.ComponentModel.DataAnnotations;

namespace HR.LeaveManagement.MVC.Models
{
    public class LeaveTypeVm : CreateLeaveTypeVm
    {
        public int Id { get; set; }
    }

    public class CreateLeaveTypeVm
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Default number of days")]
        public int DefaultDays { get; set; }
    }
}
