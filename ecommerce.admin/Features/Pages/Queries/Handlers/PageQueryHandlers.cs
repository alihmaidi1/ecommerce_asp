using AutoMapper;
using ecommerce.admin.Features.Pages.Queries.Models;
using ecommerce.Domain.Entities;
using ecommerce.Dto.Results.Admin.Pages;
using ecommerce.Dto.Results.Admin.Pages.Query;
using ecommerce.service.Abstract;
using ecommerce.service.Implement;
using ecommerce_shared.OperationResult;
using ecommerce_shared.OperationResult.Base;
using ecommerce_shared.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.admin.Features.Pages.Queries.Handlers
{
    public class PageQueryHandlers :
        IRequestHandler<GetAllPagesQuery, OperationResultBase<PageList<GetAllPagesResult>>>,
        IRequestHandler<GetPageById, OperationResultBase<GetPageByIdResult>>
    {

        #region Field
        private IPageService pageService;
        private IMapper Mapper;



        #endregion
        #region constructor

        public PageQueryHandlers(IPageService PageService, IMapper Mapper)
        {

            pageService = PageService;
            this.Mapper = Mapper;
        }

        #endregion
        public async Task<OperationResultBase<PageList<GetAllPagesResult>>> Handle( GetAllPagesQuery request, CancellationToken cancellationToken)
        {

            var PagesList = await pageService.GetPagesQueryable().Select(GetAllPagesResult.GetAllPage).ToPagedList(request.pageNumber,request.pageSize);
            
              
             return  OperationResult<PageList<GetAllPagesResult>>.Success(PagesList);
        }

        public async Task<OperationResultBase<GetPageByIdResult>> Handle(GetPageById request, CancellationToken cancellationToken)
        {

            var Page = await pageService.GetPagesByIdAsync(request.Id);
            var PageResponse = Mapper.Map<GetPageByIdResult>(Page);
            return OperationResult<GetPageByIdResult>.Success(PageResponse);
        }
    }
}
