﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialTest.Core.Models.ServiceModels
{
    public class AuthConfigResponse
    {
        public string ClientId { get; set; }
        public string Scope { get; set; }
        public string AuthorizeUrl { get; set; }
        public string RedirectUrl { get; set; }
    }
}
