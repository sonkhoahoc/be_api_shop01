using System.ComponentModel.DataAnnotations.Schema;

namespace be_api_shop01.Entities
{
    [Table("slider")]
    public class Slider: IAuditableEntity
    {
        public string url { get; set; }
        public string note { get; set; }
    }
}
