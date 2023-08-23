using ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Dto.Base
{
    public class TokenDto
    {


        public string Token { get; set; }

        public string ?RefreshToken { get; set; }

        public int ExpiredAt { get; set; }

        public static TokenDto ToTokenDto(string Token,int ExpiredAt,RefreshToken RefreshToken=null)
        {

            return new TokenDto
            {
                Token=Token,
                ExpiredAt=ExpiredAt,
                RefreshToken=RefreshToken.Token

            };

        }
    }
}
