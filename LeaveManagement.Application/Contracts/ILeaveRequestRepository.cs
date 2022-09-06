using LeaveManagement.Data;
using LeaveManagement.Common.Models;

namespace LeaveManagement.Application.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<bool> CreateLeaveRequestAsync(LeaveRequestCreateVM model);
        Task<EmployeeLeaveRequestVM> GetMyLeaveDetailsAsync();
        Task<LeaveRequestVM?> GetLeaveRequestAsync(int? id);
        Task<List<LeaveRequestVM>> GetAllAsync(string employeeId);
        Task ChangeApprovalStatusAsync(int leaveRequestId, bool approved);
        Task CancelLeaveRequestAsync(int leaveRequestId);
        Task<AdminLeaveRequestViewVM> GetAdminLeaveRequestListAsync();
    }
}
