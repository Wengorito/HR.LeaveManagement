using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly LeaveManagementDbContext _dbContext;

        public LeaveRequestRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approvalStatus)
        {
            leaveRequest.Approved = approvalStatus;
            await Update(leaveRequest);
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
        {
            return await _dbContext.LeaveRequests.Include(q => q.LeaveType).ToListAsync();
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            return await _dbContext.LeaveRequests.Include(q => q.LeaveType).FirstOrDefaultAsync(q => q.Id == id);
        }
    }
}