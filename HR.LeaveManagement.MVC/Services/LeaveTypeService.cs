using AutoMapper;
using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Models;
using HR.LeaveManagement.MVC.Services.Base;
using System;
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

        public async Task<Response<int>> CreateLeaveType(CreateLeaveTypeVm leaveType)
        {
            try
            {
                var response = new Response<int>();
                var createLeaveType = _mapper.Map<CreateLeaveTypeDto>(leaveType);
                var apiResponse = await _client.LeaveTypesPOSTAsync(createLeaveType);

                // Http-wise response can be 200 and still operation failed due to api (eg validation) hence checkiing Success flag

                if(apiResponse.Success)
                {
                    response.Data = apiResponse.Id;
                    response.Success= true;
                }
                else
                {
                    foreach(var error in apiResponse.Errors)
                    {
                        response.ValidationErrors += error + Environment.NewLine;
                    }
                }
                return response;
            }
            catch(ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<Response<int>> DeleteLeaveType(int id)
        {
            try
            {
                await _client.LeaveTypesDELETEAsync(id);
                return new Response<int> { Success = true };
            }
            catch(ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<LeaveTypeVm> GetLeaveTypeDetails(int id)
        {
            var leaveType = await _client.LeaveTypesGETAsync(id);
            return _mapper.Map<LeaveTypeVm>(leaveType);
        }

        public async Task<List<LeaveTypeVm>> GetLeaveTypes()
        {
            var leaveTypes = await _client.LeaveTypesAllAsync();
            return _mapper.Map<List<LeaveTypeVm>>(leaveTypes);
        }

        public async Task<Response<int>> UpdateLeaveType(LeaveTypeVm leaveType)
        {
            try
            {
                var leaveTypeDto = _mapper.Map<LeaveTypeDto>(leaveType);
                await _client.LeaveTypesPUTAsync(leaveTypeDto);
                return new Response<int> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }
    }
}
