using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Common;
using DataAccessLayer.Contexts;
using EntityLayer.Concrete.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
	public class ProductRepository : GenericRepository<Product>, IProductRepository
	{
		public ProductRepository(FootDbContext context) : base(context)
		{
		}

		public async Task<IEnumerable<Product>> GetProducts()
		{
			return await Table.Include(x => x.Category).Include(x => x.Brand).ToListAsync();
		}

	}
}
