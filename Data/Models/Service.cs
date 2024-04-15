
namespace SpaceSRM.Models
{
    [Serializable]
    public class Service
    {
        public int Id { get; set; }
        //Назва послуги
        public string Name { get; set; }
        //Тип послуги
        public string Type { get; set; }
        //Процент працівнику
        public float Procent { get; set; }
        //Ціна
        public float Price { get; set; }
        //Скільки робіт зробили цією послугою
        public virtual ICollection<Work> Works { get; set; } = new List<Work>();
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Service other = (Service)obj;
            return Id == other.Id; // Порівняння за унікальним полем, наприклад, Id
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode(); // Хеш-код унікального поля, наприклад, Id
        }


    }
    

}
