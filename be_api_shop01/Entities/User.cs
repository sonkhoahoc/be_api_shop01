using System.ComponentModel.DataAnnotations.Schema;

namespace be_api_shop01.Entities
{
    [Table("user")]
    public class User: IAuditableEntity
    {
        public string username { get; set; } = "";
        public string email { get; set; } = "";
        public string password { get; set; } = "";
        public string passcode { get; set; } = "";
        public int phone { get; set; }
        public string fullname { get; set; } = "";
        public string address { get; set; } = "";
        public string avatar { get; set; }
        public bool is_active { get; set; }
    }
}
