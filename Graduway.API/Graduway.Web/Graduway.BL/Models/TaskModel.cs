namespace Graduway.BL.Models
{
    public class TaskModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Estimate { get; set; }
        public int StateId { get; set; }
        public int PriorityLevelId { get; set; }
        public int EmployeeId { get; set; }
    }
}
