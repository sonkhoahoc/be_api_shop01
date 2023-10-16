using System.ComponentModel.DataAnnotations.Schema;

namespace be_api_shop01.Entities
{
    [Table("product")]
    public class Products : IAuditableEntity
    {
        public long category_id { get; set; }
        public string name { get; set; } = "";
        public double price { get; set; }
        public int views_count { get; set; }
        public int stock_quantity { get; set; }
        public int sold_quantity { get; set; }
        public string description { get; set; }
        public string avatar { get; set; }
    } 
}
