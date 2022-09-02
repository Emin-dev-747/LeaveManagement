using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;

namespace LeaveManagement.Web.Contracts
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task LeaveAllocationAsync(int leaveTypeId);
        Task<bool> AllocationExistsAsync(string employeeId, int leaveTypeId, int period);
        Task<EmployeeAllocationVM> GetEmployeeAllocationsAsync(string employeeId);
        Task<LeaveAllocation?> GetEmployeeAllocationAsync(string employeeId, int leaveTypeId);
        Task<LeaveAllocationEditVM> GetEmployeeAllocationAsync(int id);
        Task<bool> UpdateEmployeeAllocationAsync(LeaveAllocationEditVM model);
    }
}
