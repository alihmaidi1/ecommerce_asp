using AutoMapper;
using ecommerce.admin.Pages.Queries.Models;
using ecommerce.admin.Pages.Queries.Result;
using ecommerce.Domain.Entities;
using ecommerce.service.Abstract;
using ecommerce.service.Implement;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.admin.Pages.Queries.Handlers
{
    public class GetAllPagesHandlers : IRequestHandler<GetAllPagesQuery, List<GetAllPagesResult>>
    {

        #region Field
        private IPageService pageService;
        private IMapper Mapper;



        #endregion
        #region constructor

        public GetAllPagesHandlers(IPageService PageService,IMapper Mapper) {
        
            this.pageService= PageService;
            this.Mapper = Mapper;
        }

        #endregion
        public async Task<List<GetAllPagesResult>> Handle(GetAllPagesQuery request, CancellationToken cancellationToken)
        {

           var PagesList= await this.pageService.GetPagesListAsync();
           var PagesListResponse = this.Mapper.Map<List<GetAllPagesResult>>(PagesList);
            return PagesListResponse;
        }
    }
}
