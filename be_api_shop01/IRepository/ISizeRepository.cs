﻿using be_api_shop01.Entities;

namespace be_api_shop01.IRepository
{
    public interface ISizeRepository
    {
        public Task<List<Size>> GetAllSize();
        public Task<List<Size>> GetListSizrByProId(long productId);
        public Task<Size> GetSizeById(long id);
        public Task<Size> AddSize(Size size);
        public Task<Size> UpdateSize(long id, Size size);
        public Task<bool> DeleteSize(long id);
    }
}
