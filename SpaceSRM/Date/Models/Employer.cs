

namespace SpaceSRM.Models
{
    public class Employer
    {
        
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string SurName { get; set; } = "";
        public string Phone { get; set; } = "";
        public ICollection<Work> Works { get; set; } = new List<Work>();
        public ICollection<Salary> Salaries { get; set; } = new List<Salary>();
      
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Employer other = (Employer)obj;
            return Id == other.Id; // Порівняння за унікальним полем, наприклад, Id
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode(); // Хеш-код унікального поля, наприклад, Id
        }

    }
   

}
