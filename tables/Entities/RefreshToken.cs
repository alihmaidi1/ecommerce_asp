using ecommerce.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.Entities
{
    public class RefreshToken
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Token { get; set; }

        public DateTime ExpireAt { get; set; }

        public bool IsExpired => DateTime.UtcNow >= ExpireAt;

        public Guid AccountId { get; set; }

        public Account Account { get; set; }


    }
}
