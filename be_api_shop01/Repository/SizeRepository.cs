using be_api_shop01.Entities;
using be_api_shop01.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace be_api_shop01.Repository
{
    public class SizeRepository : ISizeRepository
    {
        private readonly ApplicationContext _context;

        public SizeRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Size> AddSize(Size size)
        {
            size.dateAdded = DateTime.Now;
            size.dateUpdated = DateTime.Now;

            _context.Size.Add(size);
            await _context.SaveChangesAsync();
            return size;
        }

        public async Task<bool> DeleteSize(long id)
        {
            var sizes = await _context.Size.FirstOrDefaultAsync(s => s.id == id);
            if (sizes != null)
            {
                _context.Size.Remove(sizes);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Size>> GetAllSize()
        {
            return await _context.Size.OrderByDescending(s => s.dateAdded).ToListAsync();
        }

        public async Task<List<Size>> GetListSizrByProId(long productId)
        {
            return await _context.Size.Where(s => s.product_id == productId).OrderByDescending(s => s.dateAdded).ToListAsync();
        }

        public async Task<Size> GetSizeById(long id)
        {
            return await _context.Size.FirstOrDefaultAsync(s => s.id == id);
        }

        public async Task<Size> UpdateSize(long id, Size size)
        {
            var up_size = await _context.Size.FirstOrDefaultAsync(s => s.id == id);
            if (up_size == null)
            {
                return null;
            }

             up_size.product_id = size.product_id;
             up_size.name = size.name;
             up_size.quantity = size.quantity;

             _context.Entry(up_size).State = EntityState.Modified;
             await _context.SaveChangesAsync();

            return up_size;
        }
    }
}
