using System;

namespace SocialTest.Core.Models
{
    public class AuthConfig
    {
        public string ClientId { get; set; }
        public string Scope { get; set; }
        public Uri AuthorizeUrl { get; set; }
        public Uri RedirectUrl { get; set; }
    }
}
