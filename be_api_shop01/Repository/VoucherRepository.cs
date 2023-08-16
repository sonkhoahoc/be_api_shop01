using be_api_shop01.Entities;
using be_api_shop01.IRepository;
using Microsoft.EntityFrameworkCore;

namespace be_api_shop01.Repository
{
    public class VoucherRepository : IVoucherRepository
    {
        private readonly ApplicationContext _context;

        public VoucherRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<long> AddVoucher(Voucher voucher)
        {
            voucher.dateAdded = DateTime.Now;
            voucher.dateUpdated = DateTime.Now;

            _context.Voucher.Add(voucher);
            await _context.SaveChangesAsync();
            return voucher.id;
        }

        public async Task<bool> DeleteVoucher(long id)
        {
            var id_delete = await _context.Voucher.FirstOrDefaultAsync(v => v.id == id);
            if (id_delete != null)
            {
                _context.Voucher.Remove(id_delete);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Voucher>> GetAllVoucher()
        {
            return await _context.Voucher.OrderByDescending(v => v.dateAdded).ToListAsync();
        }

        public async Task<Voucher> GetVoucherById(long id)
        {
            return await _context.Voucher.FirstOrDefaultAsync(v => v.id == id);
        }

        public async Task UpdateVoucher(long id, Voucher voucher)
        {
            var vouchers = await _context.Voucher.FirstOrDefaultAsync(v => v.id == id);
            if (vouchers != null)
            {
                vouchers.name = voucher.name;
                vouchers.code = voucher.code;
                vouchers.is_apply_count = voucher.is_apply_count;
                voucher.max_apply_count = voucher.max_apply_count;
                voucher.discount_cash = voucher.discount_cash;
                voucher.type = voucher.type;
                
                await _context.SaveChangesAsync();
            }
        }
    }
}
