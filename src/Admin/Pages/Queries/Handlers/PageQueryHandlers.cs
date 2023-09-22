//using AutoMapper;
//using ecommerce.admin.Pages.Queries.Models;
//using ecommerce.Domain.SharedResources;
//using ecommerce.Dto.Results.Admin.Pages;
//using ecommerce.Dto.Results.Admin.Pages.Query;
//using ecommerce.service.PageService;
//using ecommerce_shared.OperationResult;
//using ecommerce_shared.Pagination;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Localization;

//namespace ecommerce.admin.Pages.Queries.Handlers
//{
//    public class PageQueryHandlers : OperationResult,
//        IRequestHandler<GetAllPagesQuery, JsonResult>,
//        IRequestHandler<GetPageById, JsonResult>
//    {

//        #region Field
//        private IPageService pageService;
//        private IMapper Mapper;
//        IStringLocalizer<SharedResource> stringLocalizer;


//        #endregion
//        #region constructor

//        public PageQueryHandlers(IPageService PageService, IMapper Mapper, IStringLocalizer<SharedResource> stringLocalizer)
//        {

//            pageService = PageService;
//            this.Mapper = Mapper;
//            this.stringLocalizer = stringLocalizer;
//        }

//        #endregion
//        public async Task<JsonResult> Handle(GetAllPagesQuery request, CancellationToken cancellationToken)
//        {

//            var PagesList = await pageService.GetPagesQueryable().Select(GetAllPagesResult.GetAllPage).ToPagedList(request.pageNumber, request.pageSize);


//            return Success(PagesList);
//        }

//        public async Task<JsonResult> Handle(GetPageById request, CancellationToken cancellationToken)
//        {

//            var Page = await pageService.GetPagesByIdAsync(request.Id);
//            var PageResponse = Mapper.Map<GetPageByIdResult>(Page);
//            return Success(PageResponse);
//        }
//    }
//}
