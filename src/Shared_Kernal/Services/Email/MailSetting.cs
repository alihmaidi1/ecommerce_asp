﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.Services.Email
{
    public class MailSetting
    {
        public string From { get; set; }
        public string SmtpServer { get; set; }      
        public int Port { get; set; }               
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
