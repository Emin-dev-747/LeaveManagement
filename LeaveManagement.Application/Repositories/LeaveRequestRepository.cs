using AutoMapper;
using AutoMapper.QueryableExtensions;
using LeaveManagement.Application.Contracts;
using LeaveManagement.Data;
using LeaveManagement.Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace LeaveManagement.Application.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly UserManager<Employee> _userManager;
        private readonly AutoMapper.IConfigurationProvider _configurationProvider;
        private readonly IEmailSender _emailSender;

        public LeaveRequestRepository(ApplicationDbContext context, IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            ILeaveAllocationRepository leaveAllocationRepository,
            AutoMapper.IConfigurationProvider configurationProvider,
            IEmailSender emailSender,
            UserManager<Employee> userManager
            ) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _leaveAllocationRepository = leaveAllocationRepository;
            _configurationProvider = configurationProvider;
            _userManager = userManager;
            _emailSender = emailSender;
        }

        public async Task CancelLeaveRequestAsync(int leaveRequestId)
        {
            var leaveRequest = await GetAsync(leaveRequestId);
            leaveRequest.Cancelled = true;
            await UpdateAsync(leaveRequest);

            var user = await _userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId);

            await _emailSender.SendEmailAsync(user.Email, "Leave request Cancelled", "Your leave request from" +
                $"{leaveRequest.StartDate} to {leaveRequest.EndDate} has been Cancelled Successfully");

        }

        public async Task ChangeApprovalStatusAsync(int leaveRequestId, bool approved)
        {
            var leaveRequest = await GetAsync(leaveRequestId);
            leaveRequest.Approved = approved;

            if (approved)
            {
                var leaveAllocation = await _leaveAllocationRepository.GetEmployeeAllocationAsync(leaveRequest.RequestingEmployeeId, leaveRequest.LeaveTypeId);
                int daysRequested = (int)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;
                leaveAllocation.NumberOfDays -= daysRequested;

                await _leaveAllocationRepository.UpdateAsync(leaveAllocation);
            }

            await UpdateAsync(leaveRequest);

            var user = await _userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId);
            var approvalStatus = approved ? "Approved" : "Declined";


            await _emailSender.SendEmailAsync(user.Email, $"Leave request {approvalStatus}", "Your leave request from" +
                $"{leaveRequest.StartDate} to {leaveRequest.EndDate} has been {approvalStatus}");
        }

        public async Task<bool> CreateLeaveRequestAsync(LeaveRequestCreateVM model)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor?.HttpContext?.User);

            var leaveAllocation = await _leaveAllocationRepository.GetEmployeeAllocationAsync(user.Id, model.LeaveTypeId);

            if (leaveAllocation == null)
                return false;

            int daysRequested = (int)(model.EndDate - model.StartDate).TotalDays;

            if (daysRequested > leaveAllocation.NumberOfDays)
                return false;
            
            var leaveRequest = _mapper.Map<LeaveRequest>(model);
            leaveRequest.DateRequested = DateTime.Now;
            leaveRequest.RequestingEmployeeId = user.Id;

            await AddAsync(leaveRequest);

            await _emailSender.SendEmailAsync(user.Email, "Leave request submited successfully", "Your leave request from" +
                $"{leaveRequest.StartDate} to {leaveRequest.EndDate} has been submitted for aapproval");

            return true;
        }

        public async Task<AdminLeaveRequestViewVM> GetAdminLeaveRequestListAsync()
        {
            var leaveRequests = await _context.LeaveRequests.Include(x => x.LeaveType).ToListAsync();
            var model = new AdminLeaveRequestViewVM
            {
                TotalRequests = leaveRequests.Count,
                ApprovedRequests = leaveRequests.Count(q => q.Approved == true),
                PendingRequests = leaveRequests.Count(l => l.Approved == null),
                RejectedRequests = leaveRequests.Count(l => l.Approved == false),
                LeaveRequest = _mapper.Map<List<LeaveRequestVM>>(leaveRequests)
            };

            foreach (var leaveRequest in model.LeaveRequest)
            {
                leaveRequest.Employee = _mapper.Map<EmployeeListVM>(await _userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId));
            }

            return model;
        }

        public async Task<List<LeaveRequestVM>> GetAllAsync(string employeeId)
        {
            return await _context.LeaveRequests
                .Where(q => q.RequestingEmployeeId == employeeId)
                .ProjectTo<LeaveRequestVM>(_configurationProvider)
                .ToListAsync();
        }

        public async Task<LeaveRequestVM?> GetLeaveRequestAsync(int? id)
        {
            var leaveRequest = await _context.LeaveRequests
                .Include(x => x.LeaveType)
                .ProjectTo<LeaveRequestVM>(_configurationProvider)
                .FirstOrDefaultAsync(q => q.Id == id);
            if (leaveRequest == null)
            {
                return null;
            }

            var model = leaveRequest;
            model.Employee = _mapper.Map<EmployeeListVM>(await _userManager.FindByIdAsync(leaveRequest?.RequestingEmployeeId));
            return model;
        }

        public async Task<EmployeeLeaveRequestVM> GetMyLeaveDetailsAsync()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor?.HttpContext?.User);

            var allocations = (await _leaveAllocationRepository.GetEmployeeAllocationsAsync(user.Id)).LeaveAllocations;
            var requests = await GetAllAsync(user.Id);

            return new EmployeeLeaveRequestVM(allocations, requests);
        }
    }
}
