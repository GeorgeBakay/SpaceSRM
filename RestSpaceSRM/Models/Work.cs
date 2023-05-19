using System.ComponentModel.DataAnnotations;

namespace RestSpaceSRM.Models
{
    public class Work
    {
        [Key]
        public int Id { get; set; }
        //Працівник, працівники які займаються роботою
        public ICollection<Employer> Employers { get; set; } = new List<Employer>();
        //яку роботу виконують
        public int ServiceId { get; set; }
        public Service Service { get; set; }

    }
}
