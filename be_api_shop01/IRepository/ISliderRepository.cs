using be_api_shop01.Entities;

namespace be_api_shop01.IRepository
{
    public interface ISliderRepository
    {
        public Task<List<Slider>> GetAllSlider();
        public Task<Slider> GetSliderById(long id);
        public Task<Slider> AddSlider(Slider slider);
        public Task<Slider> UpdateSlider(long id, Slider slider);
        public Task<bool> DeleteSlider(long id);
    }
}
