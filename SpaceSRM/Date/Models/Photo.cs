using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SpaceSRM.Models
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }
        public string FileExtention { get; set; }
        public byte[] Bytes { get; set; }
        public long Size { get; set; } = 0;
        public int RecordId { get; set; }
        public virtual Record Record { get; set; } = new Record();
        public PhotoType Type { get; set; }

    }
    public enum PhotoType
    {
        Before,
        After
    }
}
