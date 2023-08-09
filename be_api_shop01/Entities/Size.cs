using System.ComponentModel.DataAnnotations.Schema;

namespace be_api_shop01.Entities
{
    [Table("size")]
    public class Size: IAuditableEntity 
    {
        public long product_is { get; set; }
        public string name { get; set; }
        public long quantity { get; set; }
    }
}
