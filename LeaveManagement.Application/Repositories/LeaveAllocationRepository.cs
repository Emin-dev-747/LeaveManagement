using AutoMapper;
using AutoMapper.QueryableExtensions;
using LeaveManagement.Common.Constants;
using LeaveManagement.Application.Contracts;
using LeaveManagement.Data;
using LeaveManagement.Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Application.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Employee> _userManager;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        private readonly AutoMapper.IConfigurationProvider _configurationProvider;
        private readonly IEmailSender _emailSender;


        public LeaveAllocationRepository(ApplicationDbContext context,
            UserManager<Employee> userManager,
            ILeaveTypeRepository leaveTypeRepository,
            AutoMapper.IConfigurationProvider configurationProvider,
            IEmailSender emailSender,
            IMapper mapper) : base(context)
        {
            _context = context;
            _userManager = userManager;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
            _emailSender = emailSender;
            _configurationProvider = configurationProvider; 
        }

        public async Task<bool> AllocationExistsAsync(string employeeId, int leaveTypeId, int period)
        {
            return await _context.LeaveAllocations.AnyAsync(q => q.EmployeeId == employeeId
                                                                && q.LeaveTypeId == leaveTypeId
                                                                && q.Period == period);
        }

        public async Task<EmployeeAllocationVM> GetEmployeeAllocationsAsync(string employeeId)
        {
            var allocations = await _context.LeaveAllocations
                .Include(q => q.LeaveType)
                .Where(q => q.EmployeeId == employeeId)
                .ProjectTo<LeaveAllocationVM>(_configurationProvider)
                .ToListAsync();
            var employee = await _userManager.FindByIdAsync(employeeId);

            var employeeAllocationModel = _mapper.Map<EmployeeAllocationVM>(employee);
            employeeAllocationModel.LeaveAllocations = allocations;
            return employeeAllocationModel;
        }

        public async Task<LeaveAllocationEditVM> GetEmployeeAllocationAsync(int id)
        {
            var allocation = await _context.LeaveAllocations
                .Include(q => q.LeaveType)
                .ProjectTo<LeaveAllocationEditVM>(_configurationProvider)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (allocation == null)
                return null;

            var employee = await _userManager.FindByIdAsync(allocation.EmployeeId);

            var model = allocation;
            model.Employee = _mapper.Map<EmployeeListVM>(employee);

            return model;
        }

        public async Task LeaveAllocationAsync(int leaveTypeId)
        {
            var employees = await _userManager.GetUsersInRoleAsync(Roles.User);
            var period = DateTime.Now.Year;
            var leaveType = await _leaveTypeRepository.GetAsync(leaveTypeId);
            var allocations = new List<LeaveAllocation>();
            var employeesWithAllocations = new List<Employee>();

            foreach (var employee in employees)
            {
                if (await AllocationExistsAsync(employee.Id, leaveTypeId, period))
                    continue;

                allocations.Add(new LeaveAllocation
                {
                    EmployeeId = employee.Id,
                    LeaveTypeId = leaveTypeId,
                    Period = period,
                    DateCreated = DateTime.Now,
                    NumberOfDays = leaveType.DefaultDays
                });
                employeesWithAllocations.Add(employee);
            }

            await AddRangeAsync(allocations);

            foreach (var employee in employeesWithAllocations)
            {
                await _emailSender.SendEmailAsync(employee.Email, $"Leave Allocation posted for {period}", $"Your {leaveType.Name}" +
               $"has been posted for the period of {period}. You have been given {leaveType.DefaultDays}.");
            }
        }

        public async Task<bool> UpdateEmployeeAllocationAsync(LeaveAllocationEditVM model)
        {
            var leaveAllocation = await GetAsync(model.Id);
            if (leaveAllocation == null)
            {
                return false;
            }
            leaveAllocation.Period = model.Period;
            leaveAllocation.NumberOfDays = model.NumberOfDays;
            await UpdateAsync(leaveAllocation);

            var user = await _userManager.FindByIdAsync(leaveAllocation.EmployeeId);

            await _emailSender.SendEmailAsync(user.Email, $"Leave Allocation updated for {leaveAllocation.Period}", 
               "Please review your leave allocations.");

            return true;
        }

        public async Task<LeaveAllocation?> GetEmployeeAllocationAsync(string employeeId, int leaveTypeId)
        {
            return await _context.LeaveAllocations.FirstOrDefaultAsync(x => x.EmployeeId == employeeId && x.LeaveTypeId == leaveTypeId);
        }
    }
}
