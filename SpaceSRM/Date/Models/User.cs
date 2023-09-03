

using System.Text.Json.Serialization;

namespace SpaceSRM.Date.Models
{
    [Serializable]
    public class User
    {
        public string userName { get; set; } = "";
        public string password { get; set; } = "";
    }
}
