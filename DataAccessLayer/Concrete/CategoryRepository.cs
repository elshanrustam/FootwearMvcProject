using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Common;
using DataAccessLayer.Contexts;
using EntityLayer.Concrete.Classes;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(FootDbContext context) : base(context)
    {
    }

}
