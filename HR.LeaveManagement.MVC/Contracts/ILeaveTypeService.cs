using HR.LeaveManagement.MVC.Models;
using HR.LeaveManagement.MVC.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR.LeaveManagement.MVC.Contracts
{
    public interface ILeaveTypeService
    {
        Task<List<LeaveTypeVm>> GetLeaveTypes();
        Task<LeaveTypeVm> GetLeaveTypeDetails(int id);
        Task<Response<int>> CreateLeaveType(CreateLeaveTypeVm leaveType);
        Task<Response<int>> UpdateLeaveType(LeaveTypeVm leaveType);
        Task<Response<int>> DeleteLeaveType(int id);
    }
}
