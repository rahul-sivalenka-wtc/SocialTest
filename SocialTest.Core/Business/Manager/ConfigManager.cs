using SocialTest.Core.Business.Manager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialTest.Core.Models;
using SocialTest.Core.Models.ServiceModels;
using SocialTest.Core.Business.Service.Interfaces;

namespace SocialTest.Core.Business.Manager
{
    public class ConfigManager : IConfigManager
    {
        /// <summary>
        /// An <see cref="IConfigService"/> implementation instance which provides the services
        /// get the config.
        /// </summary>
        public IConfigService ConfigService { get; set; }

        /// <summary>
        /// The config object.
        /// </summary>
        public ConfigModel Config { get; set; }

        /// <summary>
        /// The device for which the ConfigManager corresponds to.
        /// </summary>
        public Device Device { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="configService">An <see cref="IConfigService"/> implementation 
        /// instance injected as a dependency.</param>
        public ConfigManager(IConfigService configService)
        {
            ConfigService = configService;
        }

        /// <summary>
        /// A method to get the authentication config for a specific provider.
        /// </summary>
        /// <param name="provider">A value from <see cref="AuthProvider"/> enum.</param>
        /// <returns>An awaitable task with an <see cref="AuthConfig"/> object specific to the provider.</returns>
        public async Task<AuthConfig> GetAuthConfig(AuthProvider provider)
        {
            return (await GetConfig()).Auth[provider.ToString().ToLowerInvariant()];
        }

        /// <summary>
        /// A method to get the config for the application.
        /// </summary>
        /// <returns>An awaitable task with an <see cref="ConfigModel"/> object instance.</returns>
        public async Task<ConfigModel> GetConfig()
        {
            if (Config == null)
            {
                Config = await ReadConfigFromSource();
            }

            return Config;
        }

        private async Task<ConfigModel> ReadConfigFromSource()
        {
            var res = await ConfigService.GetConfig(Device);

            var configModel = new ConfigModel();

            configModel.Auth = (from r in res.Auth
                                select r).ToDictionary(x => x.Key, x => new AuthConfig
                                {
                                    ClientId = x.Value.ClientId,
                                    Scope = x.Value.Scope,
                                    AuthorizeUrl = new Uri(x.Value.AuthorizeUrl),
                                    RedirectUrl = new Uri(x.Value.RedirectUrl)
                                });


            return configModel;
        }
    }
}
