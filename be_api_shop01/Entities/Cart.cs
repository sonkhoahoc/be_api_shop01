using System.ComponentModel.DataAnnotations.Schema;

namespace be_api_shop01.Entities
{
    [Table("cart")]
    public class Cart: IAuditableEntity
    {
        public long product_id { get; set; }
        public long size_id { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public double total_price { get; set; }
    }
}
