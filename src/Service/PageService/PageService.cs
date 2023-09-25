//using ecommerce.Domain.Entities.Page;
//using ecommerce.Repository.Page;
//using ecommerce_shared.Exceptions;
//using Microsoft.EntityFrameworkCore;


//namespace ecommerce.service.PageService
//{
//    public class PageService : IPageService
//    {
//        protected IPageRepository PageRepository;
//        public PageService(IPageRepository PageRepository)
//        {

//            this.PageRepository = PageRepository;
//        }

//        public async Task<bool> AddPageAsync(Page page)
//        {

//            var PageResult = PageRepository.GetTableAsNoTracking()
//                .Where(pagetable => pagetable.Name.Equals(page.Name))
//                .FirstOrDefault();
//            if (PageResult != null)
//            {
//                throw new ExistsException(nameof(Page));
//            }
//            await PageRepository.AddAsync(page);
//            return true;

//        }

//        public async Task<bool> DeletePageAsync(Guid Id)
//        {
//            int deletedRaw = PageRepository.GetTableAsTracking().Where(x => x.Id == Id).ExecuteDelete();
//            if (deletedRaw == 0)
//            {
//                throw new NotFoundException(nameof(Page));
//            }
//            return true;

//        }

//        public async Task<Page> GetPagesByIdAsync(Guid Id)
//        {

//            Page page = await PageRepository.GetByIdAsync(Id);
//            if (page == null)
//            {
//                throw new NotFoundException(nameof(Page));
//            }
//            return page;

//        }

//        public async Task<List<Page>> GetPagesListAsync()
//        {

//            return await PageRepository.GetAllasync();
//        }

//        public IQueryable<Page> GetPagesQueryable()
//        {
//            return PageRepository.GetTableAsNoTracking();
//        }
//    }
//}
