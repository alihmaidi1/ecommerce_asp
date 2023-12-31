﻿using Common.Features.Token.Commands.Models;
using ecommerce.Domain.Entities.Identity;
using ecommerce.Domain.SharedResources;
using ecommerce.Dto.Base;
using ecommerce.infrutructure;
using ecommerce_shared.Enums;
using ecommerce_shared.OperationResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Repositories.Jwt;
using Repositories.Jwt.Factory;
using Repositories.RefreshToken;


namespace Common.Features.Token.Commands.Handlers
{
    public class TokenCommandHandler : OperationResult,
        IRequestHandler<RefreshTheTokenCommand, JsonResult>
    {

        public IStringLocalizer<SharedResource> stringLocalizer;
        public ApplicationDbContext DbContext;

        public IRefreshTokenRepository RefreshTokenRepository;
        
        public IJwtRepository JwtRepository;

        public TokenCommandHandler(IStringLocalizer<SharedResource> stringLocalizer, ApplicationDbContext DbContext, ISchemaFactory SchemaFactory,IRefreshTokenRepository RefreshTokenRepository) 
        {

            this.DbContext=DbContext;
            this.JwtRepository= SchemaFactory.CreateJwt(JwtSchema.Main);
            this.stringLocalizer=stringLocalizer;
            this.RefreshTokenRepository=RefreshTokenRepository;
        }


         public async Task<JsonResult> Handle(RefreshTheTokenCommand request, CancellationToken cancellationToken)
         {
            var RefreshToken = await DbContext.RefreshTokens.Include(x => x.Account).SingleAsync(x => x.Token.Equals(request.RefreshToken));
            await RefreshTokenRepository.DeleteAsync(RefreshToken);
            Account Account = RefreshToken.Account;
            TokenDto TokenInfo = await JwtRepository.GetTokensInfo(Account);
            return Success(TokenInfo);
            
         }
    }
}
