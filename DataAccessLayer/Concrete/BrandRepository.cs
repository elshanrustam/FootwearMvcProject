using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Common;
using DataAccessLayer.Contexts;
using EntityLayer.Concrete.Classes;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete;

public class BrandRepository : GenericRepository<Brand>, IBrandRepository
{
    public BrandRepository(FootDbContext context) : base(context)
    {

    }
}
