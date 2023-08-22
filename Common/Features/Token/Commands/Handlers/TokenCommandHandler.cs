using Common.Features.Token.Commands.Models;
using ecommerce.Domain.Abstract;
using ecommerce.Domain.SharedResources;
using ecommerce.Dto.Base;
using ecommerce.infrutructure;
using ecommerce_shared.OperationResult;
using ecommerce_shared.OperationResult.Base;
using ecommerce_shared.Repository.Concrete;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Features.Token.Commands.Handlers
{
    public class TokenCommandHandler : OperationResult,
        IRequestHandler<RefreshTheTokenCommand, JsonResult>
    {

        public ApplicationDbContext DbContext;


        //public JwtRepository JwtRepository;

        public TokenCommandHandler(IStringLocalizer<SharedResource> stringLocalizer, ApplicationDbContext DbContext) : base(stringLocalizer)
        {

            this.DbContext=DbContext;
            //this.JwtRepository=JwtRepository;
        
        }


         public async Task<JsonResult> Handle(RefreshTheTokenCommand request, CancellationToken cancellationToken)
         {
            //var RefreshToken = await DbContext.RefreshTokens.Include(x => x.Account).SingleAsync(x => x.Token.Equals(request.RefreshToken));
            //Account Account = RefreshToken.Account;
            //TokenDto TokenInfo = JwtRepository.GetTokens(Account);
            //return Success<TokenDto>(TokenInfo);
            return null;
         }
    }
}
