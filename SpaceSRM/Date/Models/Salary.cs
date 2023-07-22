using SpaceSRM.Models;

namespace SpaceSRM.Models
{
    public class Salary
    {
        public int Id { get; set; } = -1;
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public int EmployerId { get; set; }
        public Employer Employer { get; set; }
    }
}
