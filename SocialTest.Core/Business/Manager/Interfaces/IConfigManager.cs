using SocialTest.Core.Models;
using SocialTest.Core.Models.ServiceModels;
using System.Threading.Tasks;

namespace SocialTest.Core.Business.Manager.Interfaces
{
    public interface IConfigManager
    {
        /// <summary>
        /// The device for which the ConfigManager corresponds to.
        /// </summary>
        Device Device { get; set; }

        /// <summary>
        /// A method to get the authentication config for a specific provider.
        /// </summary>
        /// <param name="provider">A value from <see cref="AuthProvider"/> enum.</param>
        /// <returns>An awaitable task with an <see cref="AuthConfig"/> object specific to the provider.</returns>
        Task<AuthConfig> GetAuthConfig(AuthProvider provider);

        /// <summary>
        /// A method to get the config for the application.
        /// </summary>
        /// <returns>An awaitable task with an <see cref="ConfigModel"/> object instance.</returns>
        Task<ConfigModel> GetConfig();
    }
}
