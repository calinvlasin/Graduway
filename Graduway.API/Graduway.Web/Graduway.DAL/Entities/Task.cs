using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Graduway.DAL.Entities
{
    public class Task
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Estimate { get; set; }

        public int StateId { get; set; }
        public int PriorityLevelId { get; set; }
        public int EmployeeId { get; set; }
        public State State { get; set; }
        public PriorityLevel PriorityLevel { get; set; }
        public Employee Employee { get; set; }
    }
}
