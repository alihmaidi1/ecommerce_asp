using AutoMapper;
using ecommerce.admin.Pages.Queries.Models;
using ecommerce.admin.Pages.Queries.Result;
using ecommerce.Domain.Entities;
using ecommerce.service.Abstract;
using ecommerce.service.Implement;
using ecommerce_shared.OperationResult;
using ecommerce_shared.OperationResult.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.admin.Pages.Queries.Handlers
{
    public class GetAllPagesHandlers : IRequestHandler<GetAllPagesQuery, OperationResultBase<List<GetAllPagesResult>>>
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
        public async Task<OperationResultBase<List<GetAllPagesResult>>> Handle(GetAllPagesQuery request, CancellationToken cancellationToken)
        {

           var PagesList= await this.pageService.GetPagesListAsync();
           var PagesListResponse = this.Mapper.Map<List<GetAllPagesResult>>(PagesList);
            return OperationResult<List<GetAllPagesResult>>.Success(PagesListResponse);
        }
    }
}
