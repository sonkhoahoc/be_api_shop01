using System.ComponentModel.DataAnnotations.Schema;

namespace be_api_shop01.Entities
{
    [Table("order")]
    public class Order: IAuditableEntity
    {
        public long customer_id { get; set; }
        public double total_bill { get; set; }
        public long voucher_id { get; set; }
        public double voucher_discount { get; set; }
        public string receive_info { get; set; }
        public string note { get; set; } = "";
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
