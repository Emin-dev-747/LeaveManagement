﻿using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Common.Models
{
    public class LeaveRequestVM : LeaveRequestCreateVM
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Requested")]
        public DateTime DateRequested { get; set; }

        [Display(Name = "Leave Type")]
        public LeaveTypeVM LeaveType { get; set; }
        public bool? Approved { get; set; }
        public bool Cancelled { get; set; }

        public string? RequestingEmployeeId { get; set; }
        public EmployeeListVM Employee { get; set; }
    }
}
