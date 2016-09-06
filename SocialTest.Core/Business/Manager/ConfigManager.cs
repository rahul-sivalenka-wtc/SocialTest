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
        public IConfigService ConfigService { get; set; }

        public ConfigModel Config { get; set; }

        public Device Device { get; set; }

        public ConfigManager(IConfigService configService)
        {
            ConfigService = configService;
        }

        public AuthConfig GetAuthConfig(AuthProvider provider)
        {
            throw new NotImplementedException();
        }

        public async Task<ConfigModel> GetConfig()
        {
            //#if __ANDROID__
            //            var test = "itsAndroid";
            //#endif

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
