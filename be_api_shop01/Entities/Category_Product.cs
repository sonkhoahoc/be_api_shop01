using System.ComponentModel.DataAnnotations.Schema;

namespace be_api_shop01.Entities
{
    [Table("category_product")]
    public class Category_Product : IAuditableEntity
    {
        public string name { get; set; } = "";

        //Xác định danh mục cha
        public long? parent_category_id { get; set; }

    }
}
