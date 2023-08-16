using be_api_shop01.Entities;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

namespace be_api_shop01.IRepository
{
    public interface IVoucherRepository
    {
        public Task<List<Voucher>> GetAllVoucher();
        public Task<Voucher> GetVoucherById(long id);
        public Task<long> AddVoucher(Voucher voucher);
        public Task UpdateVoucher(long id, Voucher voucher);
        public Task<bool> DeleteVoucher(long id);
    }
}
