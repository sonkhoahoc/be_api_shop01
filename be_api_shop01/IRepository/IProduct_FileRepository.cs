using be_api_shop01.Entities;

namespace be_api_shop01.IRepository
{
    public interface IProduct_FileRepository
    {
        public Task<List<Product_File>> GetListFile();
        public Task<List<Product_File>> GetListFileByPro_Id(long product_id);
        public Task<Product_File> GetFikeById(long id);
        public Task<Product_File> CreateFile( Product_File file);
        public Task<Product_File> UpdateFile(long id, Product_File file);
        public Task<bool> DeleteFile(long id);
    }
}
