using ecommerce.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.Entities
{
    [Table("Admins")]
    public class Admin : Account
    {
        //public bool IsBlocked { get; set; }

    }


}