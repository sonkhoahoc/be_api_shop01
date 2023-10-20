using be_api_shop01.Entities;
using be_api_shop01.IRepository;
using Microsoft.EntityFrameworkCore;

namespace be_api_shop01.Repository
{
    public class Product_FileRepository : IProduct_FileRepository
    {
        private readonly ApplicationContext _context;

        public Product_FileRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Product_File> CreateFile( Product_File file)
        {
            file.dateAdded = DateTime.UtcNow;
            file.dateUpdated = DateTime.UtcNow;

            _context.Product_File.Add(file);
            await _context.SaveChangesAsync();

            return file;
        }

        public async Task<bool> DeleteFile(long id)
        {
            var pro_file = await _context.Product_File.FindAsync(id);

            if (pro_file == null)
            {
                return false;
            }

            _context.Product_File.Remove(pro_file);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Product_File> GetFikeById(long id)
        {
            return await _context.Product_File.FindAsync(id);
        }

        public async Task<List<Product_File>> GetListFile()
        {
            return await _context.Product_File.OrderByDescending(p => p.dateAdded).ToListAsync();
        }

        public async Task<List<Product_File>> GetListFileByPro_Id(long product_id)
        {
            return await _context.Product_File.Where(p => p.product_id == product_id).OrderByDescending(p => p.dateAdded).ToListAsync();
        }

        public async Task<Product_File> UpdateFile(long id, Product_File file)
        {
            var pro_file = await _context.Product_File.FirstOrDefaultAsync(p => p.id == id);

            if(pro_file == null)
            {
                return null;
            }

            pro_file.product_id = file.product_id;
            pro_file.file = file.file;
            pro_file.alt_description = file.alt_description;
            _context.Entry(pro_file).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return pro_file;
        }
    }
}
