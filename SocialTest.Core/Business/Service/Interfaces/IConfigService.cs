using SocialTest.Core.Models;
using SocialTest.Core.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialTest.Core.Business.Service.Interfaces
{
    public interface IConfigService
    {
        Task<ConfigResponse> GetConfig(Device device);
    }
}
