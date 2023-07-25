using AutoMapper;
using ecommerce.admin.Features.Pages.Commands.Models;
using ecommerce.Domain.Entities;
using ecommerce.service.Abstract;
using ecommerce_shared.OperationResult;
using ecommerce_shared.OperationResult.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.admin.Features.Pages.Commands.Handlers
{
    public class PageCommandHandlers : IRequestHandler<AddPageCommand, OperationResultBase<string>>
    {

        public IPageService pageService;
        public IMapper mapper;

        public PageCommandHandlers(IPageService pageService, IMapper mapper)
        {

            this.pageService = pageService;
            this.mapper = mapper;
        }

        public async Task<OperationResultBase<string>> Handle(AddPageCommand request, CancellationToken cancellationToken)
        {
            var mapperResult = mapper.Map<Page>(request);
            var result = await pageService.AddPageAsync(mapperResult);

            if (result == false) { return OperationResult<string>.Exists(); }

            return OperationResult<string>.Success("the page was created successfully");
        }
    }
}
