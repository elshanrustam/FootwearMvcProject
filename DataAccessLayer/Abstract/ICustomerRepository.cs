﻿using DataAccessLayer.Abstract.Common;
using EntityLayer.Concrete.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
    }
}
