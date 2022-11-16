using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators
{
    public class ILeaveAllocationDtoValidator : AbstractValidator<ILeaveAllocationDto>
    {
        public ILeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            RuleFor(p => p.NumberOfDays)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .GreaterThan(0).WithMessage("{PropertyName} must be at least 1.")
                .LessThan(25).WithMessage("{PropertyName} must not exceed {ComparisonValue} days.");

            RuleFor(p => p.Period)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("{PropertyName} must not be before {ComparisonValue} period.");

            RuleFor(p => p.LeaveTypeId)
                .MustAsync(async (id, token) =>
                {
                    var leaveTypeExists = await leaveTypeRepository.Exists(id);
                    return leaveTypeExists;
                })
                .WithMessage("{PropertyName} does not exist.");
        }
    }
}
