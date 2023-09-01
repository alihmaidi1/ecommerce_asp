using ecommerce.admin.Features.Pages.Commands.Models;
using ecommerce.admin.Features.Password.Models;
using ecommerce.service.UserService;
using ecommerce_shared.OperationResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Repositories.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.admin.Features.Password.Commands
{
    public class PasswordHandlers : OperationResult,
        IRequestHandler<ForgetPasswordCommand, JsonResult>
    {
        private IAccountService AccountService;

        public PasswordHandlers(IAccountService AccountService) { 
        

            this.AccountService = AccountService;
        }
        public async Task<JsonResult> Handle(ForgetPasswordCommand request, CancellationToken cancellationToken)
        {

            bool EmailSended = await AccountService.SendEmail(request.Email);
        
            return Success(EmailSended, "The Email Was Sended Successfully");
        }
    }
}
