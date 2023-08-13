using be_api_shop01.Entities;

namespace be_api_shop01.IRepository
{
    public interface ISliderRepository
    {
        public Task<List<Slider>> GetAllSlider();
        public Task<Slider> GetSliderById(long id);
        public Task<long> AddSlider(Slider slider);
        public Task UpdateSlider(long id, Slider slider);
        public Task DeleteSlider(long id);
    }
}
