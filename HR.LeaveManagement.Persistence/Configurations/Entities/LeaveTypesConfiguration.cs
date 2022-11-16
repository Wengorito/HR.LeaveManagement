using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.LeaveManagement.Persistence.Configurations.Entities
{
    public class LeaveTypesConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            //builder.HasData(
            //    new LeaveType
            //    {
            //        Id = 1,
            //        DefaultDays = 10,
            //        Name = "Vacation"
            //    },
            //    new LeaveType
            //    {
            //        Id = 2,
            //        DefaultDays = 12,
            //        Name = "Sick"
            //    });

            builder.HasData(
                new LeaveType("Vacation", 10) { Id = 1 },
                new LeaveType("Sick", 12) { Id = 2 });
        }
    }
}
