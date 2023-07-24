using ecommerce.Domain.Entities;
using ecommerce.infrutructure;
using ecommerce_shared.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Repository.PageRepository
{
    public class PageRepository : GenericRepository<Page>, IPageRepository
    {
        public PageRepository(ApplicationDbContext DbContext) : base(DbContext)
        {
        }
    }
}
