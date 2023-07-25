﻿using ecommerce.admin.Features.Pages.Commands.Models;
using ecommerce.admin.Features.Pages.Queries.Models;
using ecommerce.Base;
using ecommerce.Domain.AppMetaData;
using ecommerce.Domain.AppMetaData.Admin;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers.Admin
{
    [ApiController]
    public class PageController : ApiController
    {
        
        [HttpGet(PageRouter.List)]
        public async Task<IActionResult> GetPageList([FromQuery] GetAllPagesQuery query)
        {

            var response =await this.Mediator.Send(query);
            
            return Ok(response);
        }



        [HttpGet(PageRouter.GetById)]
        public async Task<IActionResult> getPageById()
        {

            var response = await this.Mediator.Send(new GetPageById());
            return Ok(response);
        }



        [HttpPost(PageRouter.AddPage)]
        public async Task<IActionResult> AddPage([FromBody] AddPageCommand command)
        {

            var response = await this.Mediator.Send(command);
            return Ok(response);
        }
    }
}
