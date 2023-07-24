using ecommerce.Domain.Entities;
using ecommerce.Repository.PageRepository;
using ecommerce.service.Abstract;
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
        public async Task<List<Page>> GetPagesListAsync()
        {

            return await PageRepository.GetAllasync();
        }
    }
}
