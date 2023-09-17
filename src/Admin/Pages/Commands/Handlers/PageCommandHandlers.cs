using AutoMapper;
using ecommerce.admin.Pages.Commands.Models;
using ecommerce.Domain.Entities;
using ecommerce.Domain.SharedResources;
using ecommerce.service.PageService;
using ecommerce_shared.OperationResult;
using ecommerce_shared.OperationResult.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.admin.Pages.Commands.Handlers
{
    public class PageCommandHandlers : OperationResult,
        IRequestHandler<AddPageCommand, JsonResult>
    // IRequestHandler<DeletePageCommand, JsonResult>


    {

        public IStringLocalizer<SharedResource> _StringLocalizer;


        public IPageService pageService;
        public IMapper mapper;

        public PageCommandHandlers(IPageService pageService, IMapper mapper, IStringLocalizer<SharedResource> stringLocalizer)
        {
            _StringLocalizer = stringLocalizer;
            this.pageService = pageService;
            this.mapper = mapper;
            _StringLocalizer = stringLocalizer;
        }

        public async Task<JsonResult> Handle(AddPageCommand request, CancellationToken cancellationToken)
        {
            var mapperResult = mapper.Map<Page>(request);
            var result = await pageService.AddPageAsync(mapperResult);

            return Created<string>(_StringLocalizer[SharedResourceKeys.Page_Created_Successfully]);
        }

        //async Task<JsonResult> Handle(DeletePageCommand request, CancellationToken cancellationToken)
        //{
        //    var Result =await pageService.DeletePageAsync(request.Id);

        //    return Deleted<bool>();
        //}

    }
}
