using ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.service.Abstract
{
    public interface IPageService
    {

        public Task<List<Page>> GetPagesListAsync();

        public IQueryable<Page> GetPagesQueryable();
        public Task<Page> GetPagesByIdAsync(Guid id);

        public Task<bool> AddPageAsync(Page page);

        public Task<bool> DeletePageAsync(Guid Id);


    }
}
