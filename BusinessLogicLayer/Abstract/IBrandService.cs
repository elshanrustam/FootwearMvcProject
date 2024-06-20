using BusinessLogicLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{
    public interface IBrandService
    {
        public Task<IEnumerable<BrandViewDto>> GetBrandViewDtos();
    }
}
