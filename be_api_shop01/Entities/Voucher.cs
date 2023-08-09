using System.ComponentModel.DataAnnotations.Schema;

namespace be_api_shop01.Entities
{
    [Table("voucher")]
    public class Voucher: IAuditableEntity
    {
        public string name { get; set; } = "";
        public string code { get; set; }
        public bool is_apply_count { get; set; }
        public int max_apply_count { get; set; }
        public double discount_cash { get; set; }
        public string type { get; set; } = "";
    }
}
