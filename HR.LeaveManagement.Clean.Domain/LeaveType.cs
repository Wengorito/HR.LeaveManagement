using HR.LeaveManagement.Domain.Common;

namespace HR.LeaveManagement.Domain;

public class LeaveType : BaseDomainEntity
{
    public LeaveType(string name, int defaultDays)
    {
        Name = name;
        DefaultDays = defaultDays;
    }

    public string Name { get; set; }
    public int DefaultDays { get; set; }
    public DateTime DateCreated { get; set; }
}