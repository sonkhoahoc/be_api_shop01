using System.ComponentModel.DataAnnotations;

namespace be_api_shop01.Entities
{
    public class IAuditableEntity
    {
        [Key]
        public long id { get; set; }
        public long userAdded { get; set; } = 0;
        public long? userUpdated { get; set; }
        public DateTime dateAdded { get; set; } = DateTime.Now;
        public DateTime dateUpdated { get; set; }
        public bool is_delete { get; set; } = false;
        public void getAuditable()
        {
            if (this.id == 0)
                this.dateUpdated = DateTime.Now;
            else
                this.dateAdded = DateTime.Now;
        }
    }
}
