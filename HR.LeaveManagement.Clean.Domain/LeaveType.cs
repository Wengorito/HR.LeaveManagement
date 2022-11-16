using HR.LeaveManagement.Domain.Common;

namespace HR.LeaveManagement.Domain;

public class LeaveType : BaseDomainEntity
{
    // Constructor assures properies have values when entity created
    public LeaveType(string name, int defaultDays)
    {
        Name = name;
        DefaultDays = defaultDays;
    }

    public string Name { get; set; }
    public int DefaultDays { get; set; }
}