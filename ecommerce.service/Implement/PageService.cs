using ecommerce.Domain.Entities;
using ecommerce.Repository.PageRepository;
using ecommerce.service.Abstract;
using ecommerce_shared.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.service.Implement
{
    public class PageService : IPageService
    {
        protected IPageRepository PageRepository;
        public PageService(IPageRepository PageRepository) {
        
            this.PageRepository = PageRepository;
        }

        public  async Task<bool>AddPageAsync(Page page)
        {

            var PageResult = PageRepository.GetTableAsNoTracking()
                .Where(pagetable=>pagetable.Name.Equals(page.Name))
                .FirstOrDefault();
            if (PageResult != null) {
                throw new ExistsException(nameof(Page));
            }
            await PageRepository.AddAsync(page);
            return true;

        }

        public async Task<bool> DeletePageAsync(Guid Id)
        {
            int deletedRaw=PageRepository.GetTableAsTracking().Where(x=>x.Id==Id).ExecuteDelete();
            if (deletedRaw == 0)
            {
                throw new NotFoundException(nameof(Page));
            }
            return true;

        }

        public async Task<Page> GetPagesByIdAsync(Guid Id)
        {

            Page page= await this.PageRepository.GetByIdAsync(Id);
            if(page == null) { 
                throw new NotFoundException(nameof(Page)); 
            }
            return page;

        }

        public async Task<List<Page>> GetPagesListAsync()
        {

            return await PageRepository.GetAllasync();
        }

        public IQueryable<Page> GetPagesQueryable()
        {
            return PageRepository.GetTableAsNoTracking();
        }
    }
}
