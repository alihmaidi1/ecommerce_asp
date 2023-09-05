using BrandEntity=ecommerce.Domain.Entities.Brand;
using Repositories.Base.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecommerce.infrutructure;

namespace Repositories.Brand
{
    public class BrandRepository : GenericRepository<BrandEntity>, IBrandRepository
    {
        public BrandRepository(ApplicationDbContext DbContext) : base(DbContext)
        {
        }

        public bool IsNameExists(string Name)
        {

            return DbContext.Brands.Any(b => b.Name == Name);   
        }


    }
}
