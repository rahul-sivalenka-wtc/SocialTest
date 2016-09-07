using SocialTest.Core.Models;
using SocialTest.Core.Models.ServiceModels;
using System.Threading.Tasks;

namespace SocialTest.Core.Business.Service.Interfaces
{
    public interface IConfigService
    {
        /// <summary>
        /// Method to get the config as per the device passed. 
        /// </summary>
        /// <param name="device">A value from <see cref="Device"/> enum.</param>
        /// <returns>A <see cref="ConfigResponse"/> object.</returns>
        Task<ConfigResponse> GetConfig(Device device);
    }
}
