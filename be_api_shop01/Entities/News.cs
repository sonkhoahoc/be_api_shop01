using System.ComponentModel.DataAnnotations.Schema;

namespace be_api_shop01.Entities
{
    [Table("news")]
    public class News: IAuditableEntity
    {
        public long category_id { get; set; }
        public string title { get; set; }
        public string short_description { get; set; } = "";
        public string content { get; set; } = "";
        public string avatar { get; set; }
        public string note { get; set; } = "";
    }
}
