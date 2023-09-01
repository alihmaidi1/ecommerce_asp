<<<<<<< HEAD
﻿using ecommerce.Domain.Entities;
=======
﻿
using ecommerce.Domain.Entities;
>>>>>>> 90bac4133691690d5adc946ac38d3faf668d9f45
using ecommerce.Dto.Base;
using ecommerce.Dto.Results.User.City.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Dto.Results.User.Auth.Command
{
    public class UserWithToken
    {
    
        public Guid Id { get; set; }


        public string UserName { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public int Point { get; set; }

        public OnlyCityDto City { get; set; }


        public bool IsBlocked { get; set; }


        public TokenDto TokenInfo { get; set; }



    }
}
