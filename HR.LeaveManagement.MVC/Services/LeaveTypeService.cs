using AutoMapper;
using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Models;
using HR.LeaveManagement.MVC.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR.LeaveManagement.MVC.Services
{
    public class LeaveTypeService : BaseHttpService, ILeaveTypeService
    {
        private readonly IMapper _mapper;
        private readonly ILocalStorageService _localStorage;
        private readonly IClient _client;

        public LeaveTypeService(IMapper mapper, ILocalStorageService localStorage, IClient client) : base(localStorage, client)
        {
            _mapper = mapper;
            _localStorage = localStorage;
            _client = client;
        }

        public Task<Response<int>> CreateLeaveType(CreateLeaveTypeVM leaveType)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteLeaveType(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<LeaveTypeVM> GetLeaveTypeDetails(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<LeaveTypeVM>> GetLeaveTypes()
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateLeaveType(LeaveTypeVM leaveType)
        {
            throw new System.NotImplementedException();
        }
    }
}
