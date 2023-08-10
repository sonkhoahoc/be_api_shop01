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

        public async Task<long> AddSize(Size size)
        {
            size.dateAdded = DateTime.Now;
            size.dateUpdated = DateTime.Now;

            _context.Size.Add(size);
            await _context.SaveChangesAsync();
            return size.id;
        }

        public async Task DeleteSize(long id)
        {
            var sizes = await _context.Size.FirstOrDefaultAsync(s => s.id == id);
            if(sizes != null)
            {
                _context.Size.Remove(sizes);
                await _context.SaveChangesAsync();
            }
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

        public async Task UpdateSize(long id, Size size)
        {
            var sizes = await _context.Size.FirstOrDefaultAsync(s => s.id == id);
            if (sizes != null)
            {
                sizes.name = size.name;
                sizes.quantity = size.quantity;
                await _context.SaveChangesAsync();
            }
        }
    }
}
