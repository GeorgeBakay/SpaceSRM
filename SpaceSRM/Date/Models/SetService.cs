

using SpaceSRM.Models;

namespace SpaceSRM.Models
{
    public class SetService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Service> Services{ get; set; } = new List<Service>();
        public virtual ICollection<Record> Records { get; set; } = new List<Record>();
        public int Discount { get; set; }

    }
}
