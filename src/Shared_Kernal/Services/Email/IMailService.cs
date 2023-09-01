using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.Services.Email
{
    public interface IMailService
    {


        public bool SendMail(string Email,string code);

    }
}
