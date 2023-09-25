﻿//using ecommerce.admin.Pages.Commands.Models;
//using ecommerce.admin.Pages.Queries.Models;
//using ecommerce.Base;
//using ecommerce.Domain.AppMetaData.Admin;
//using ecommerce.Domain.Attribute;
//using ecommerce.Domain.Attributes;
//using ecommerce.Domain.Enum;
//using ecommerce_shared.Swagger;
//using Microsoft.AspNetCore.Mvc;

//namespace ecommerce.Controllers.SuperAdmin
//{
//    [ApiGroup(ApiGroupName.SuperAdmin)]
//    [AppAuthorize(RoleEnum.SuperAdmin)]

//    public class PageController : ApiController
//    {
        
//        [HttpGet(PageRouter.List)]
//        public async Task<IActionResult> GetPageList([FromQuery] GetAllPagesQuery query)
//        {

//            var response =await this.Mediator.Send(query);
            
//            return Ok(response);
//        }



//        [HttpGet(PageRouter.GetById)]

//        public async Task<IActionResult> getPageById()
//        {

//            var response = await this.Mediator.Send(new GetPageById());
//            return Ok(response);
//        }


//        [HttpPost(PageRouter.AddPage)]
//        //[CheckTokenInRedis(Policy = "DeleteBanner")]
//        public async Task<IActionResult> AddPage([FromBody] AddPageCommand command)
//        {

//            var response = await this.Mediator.Send(command);
//            return response;
//        }



//        [HttpDelete(PageRouter.Delete)]

//        //[CheckTokenInRedis]
//        public async Task<IActionResult> Delete([FromQuery] DeletePageCommand command)
//        {

//            var response = await this.Mediator.Send(command);
//            return Ok(response);
//        }
//    }
//}
