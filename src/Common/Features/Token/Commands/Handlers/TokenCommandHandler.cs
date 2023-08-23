using Common.Features.Token.Commands.Models;
using ecommerce.Domain.Abstract;
using ecommerce.Domain.SharedResources;
using ecommerce.Dto.Base;
using ecommerce.infrutructure;
using ecommerce_shared.OperationResult;
using ecommerce_shared.OperationResult.Base;
using ecommerce_shared.Repository.Concrete;
using ecommerce_shared.Repository.interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Repositories.RefreshToken;
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

        public IRefreshTokenRepository RefreshTokenRepository;
        
        public IJwtRepository JwtRepository;

        public TokenCommandHandler(IStringLocalizer<SharedResource> stringLocalizer, ApplicationDbContext DbContext, IJwtRepository JwtRepository,IRefreshTokenRepository RefreshTokenRepository) : base(stringLocalizer)
        {

            this.DbContext=DbContext;
            this.JwtRepository=JwtRepository;
            this.RefreshTokenRepository=RefreshTokenRepository;
        }


         public async Task<JsonResult> Handle(RefreshTheTokenCommand request, CancellationToken cancellationToken)
         {
            var RefreshToken = await DbContext.RefreshTokens.Include(x => x.Account).SingleAsync(x => x.Token.Equals(request.RefreshToken));
            await RefreshTokenRepository.DeleteAsync(RefreshToken);
            Account Account = RefreshToken.Account;
            TokenDto TokenInfo = await JwtRepository.GetTokens(Account);
            return Success<TokenDto>(TokenInfo);
            
         }
    }
}
