using SocialTest.Core.Models;
using SocialTest.Core.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialTest.Core.Business.Manager.Interfaces
{
    public interface IConfigManager
    {
        Device Device { get; set; }

        AuthConfig GetAuthConfig(AuthProvider provider);

        Task<ConfigModel> GetConfig();
    }
}
