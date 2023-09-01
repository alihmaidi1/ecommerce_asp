using ecommerce_shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Jwt.Factory
{
    public interface  ISchemaFactory
    {

        public IJwtRepository CreateJwt(JwtSchema Schema);

    }
}
