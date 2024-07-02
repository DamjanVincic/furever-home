using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FureverHome.Models;
using FureverHome.Repositories;

namespace FureverHome.Services
{
    public class ColorService
    {
        public readonly IColorRepository _colorRepository;

        public ColorService(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        public List<Color> getAll()
        {
            return _colorRepository.GetAll();
        }
    }
}
