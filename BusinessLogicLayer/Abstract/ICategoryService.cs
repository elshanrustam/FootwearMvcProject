﻿using BusinessLogicLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewDto>> GetAllCategoriesAsync();
    }
}
