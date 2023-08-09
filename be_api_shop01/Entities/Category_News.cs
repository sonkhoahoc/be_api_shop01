using System.ComponentModel.DataAnnotations.Schema;

namespace be_api_shop01.Entities
{
    [Table("category_news")]
    public class Category_News: IAuditableEntity
    {
        public string name { get; set; } = "";
    }
}