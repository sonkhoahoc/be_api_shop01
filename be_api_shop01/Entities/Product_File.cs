using System.ComponentModel.DataAnnotations.Schema;

namespace be_api_shop01.Entities
{
    [Table("product_file")]
    public class Product_File: IAuditableEntity
    {
        public long product_id { get; set; }
        public string file { get; set; }
        public string alt_description { get; set; } = "";
    }
}
