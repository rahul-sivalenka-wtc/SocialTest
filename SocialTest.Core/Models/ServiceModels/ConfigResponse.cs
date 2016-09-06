using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialTest.Core.Models.ServiceModels
{
    public class ConfigResponse
    {
        public Dictionary<string, AuthConfigResponse> Auth { get; set; }
        //public AuthConfigResponse Facebook { get; set; }
    }
}
