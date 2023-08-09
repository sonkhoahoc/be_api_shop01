using Microsoft.EntityFrameworkCore;

namespace be_api_shop01.Entities
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public virtual DbSet<Category_News> Category_News { get; set; }
        public virtual DbSet<Category_Product> Category_Product { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Order_detail> Order_detail { get; set; }
        public virtual DbSet<Product_File> Product_File { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Size> Size { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Voucher> Voucher { get; set; }
        public virtual DbSet<Slider> Slider { get; set; }
    }
}
