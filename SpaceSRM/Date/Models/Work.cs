
using System.Text.Json.Serialization;

namespace SpaceSRM.Models
{
    public class Work
    {
     
        public int Id { get; set; }
        //Працівник, працівники які займаються роботою
        public ICollection<Employer> Employers { get; set; } = new List<Employer>();
        //яку роботу виконують
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public int RecordId { get; set; }
        public Record Record { get; set; } = new Record();
        public int Price { get; set; }
        public int TruePrice { get; set; }
        public string DescriptionCost { get; set; } = " ";
        public int PriceCost { get; set; } = 0;

    }
}
