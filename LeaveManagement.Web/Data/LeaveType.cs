namespace LeaveManagement.Web.Data
{
    public class LeaveType : BaseEntity
    {
        public string Name { get; set; }
        public int DefultDays { get; set; }
    }
}
