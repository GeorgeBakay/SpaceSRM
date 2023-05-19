using System.ComponentModel.DataAnnotations;
using System.Web;
namespace RestSpaceSRM.Models
{
    public enum Status
    {
        Wait,
        Work,
        End,
        Abolition
    }
    public class Record
    {
        [Key]
        public int Id { get; set; }
        //Клієнт
        public int ClientId { get; set; }
        public Client Client { get; set; }
        //Марка маники
        public string Brand { get; set; }


        

        //Яку роботу потрібно виконати
        [Required]
        public ICollection<Work> Works { get; set; }
        public IFormFileCollection PhotoBefore { get; set; }
        public IFormFileCollection PhotoAfter { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public Status Status { get; set; }
        public float Sum { get; set; }
    }
}
