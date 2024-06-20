using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Common;
using DataAccessLayer.Contexts;
using EntityLayer.Concrete.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class DetailRepository : GenericRepository<Detail>, IDetailRepository
    {
        public DetailRepository(FootDbContext context) : base(context)
        {
        }
    }
}
