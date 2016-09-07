using System.Collections.Generic;

namespace SocialTest.Core.Models.ServiceModels
{
    public class ConfigResponse
    {
        public Dictionary<string, AuthConfigResponse> Auth { get; set; }
    }
}
