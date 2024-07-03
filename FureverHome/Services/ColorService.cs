using FureverHome.Models;
using FureverHome.Repositories;

namespace FureverHome.Services
{
    public class ColorService
    {
        private readonly IColorRepository _colorRepository;

        public ColorService(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        public List<Color> GetAll()
        {
            return _colorRepository.GetAll();
        }
    }
}
