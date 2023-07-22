namespace SpaceSRM.Models
{
    public class Cost
    {
        public int Id { get; set; } = -1;
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime Date { get; set; } = DateTime.Now;
        public int Price { get; set; } = 0;
    }
}
