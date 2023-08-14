using be_api_shop01.Entities;
using be_api_shop01.IRepository;
using Microsoft.EntityFrameworkCore;

namespace be_api_shop01.Repository
{
    public class SliderRepository : ISliderRepository
    {
        private readonly ApplicationContext _context;

        public SliderRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<long> AddSlider(Slider slider)
        {
            slider.dateAdded = DateTime.Now;
            slider.dateUpdated = DateTime.Now;

            _context.Slider.Add(slider);
            await _context.SaveChangesAsync();
            return slider.id;
        }

        public async Task<bool> DeleteSlider(long id)
        {
            var slider = await _context.Slider.FirstOrDefaultAsync(s => s.id == id);
            if (slider != null)
            {
                _context.Slider.Remove(slider);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Slider>> GetAllSlider()
        {
            return await _context.Slider.OrderByDescending(s => s.dateAdded).ToListAsync();
        }

        public async Task<Slider> GetSliderById(long id)
        {
            return await _context.Slider.FirstOrDefaultAsync(s => s.id == id);
        }

        public async Task UpdateSlider(long id, Slider slider)
        {
            var sliders = await _context.Slider.FirstOrDefaultAsync(s => s.id == id);
            if (sliders != null)
            {
                sliders.url = slider.url;
                sliders.note = slider.note;
                await _context.SaveChangesAsync();
            }
        }
    }
}
