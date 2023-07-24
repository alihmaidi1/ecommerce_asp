using ecommerce.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.Entities
{
    public class Admin : Account<Guid>
    {
        //public bool IsBlocked { get; set; }

    }


}