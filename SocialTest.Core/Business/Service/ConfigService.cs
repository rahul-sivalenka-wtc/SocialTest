using SocialTest.Core.Business.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialTest.Core.Models.ServiceModels;
using SocialTest.Core.Models;
using System.Reflection;
using System.IO;
using System.Xml.Linq;

namespace SocialTest.Core.Business.Service
{
    public class ConfigService : IConfigService
    {
        public async Task<ConfigResponse> GetConfig(Device device)
        {
            var type = this.GetType();
            var deviceType = "";

            switch (device)
            {
                case Device.IOS:
                    deviceType = "ios";
                    break;
                case Device.ANDROID:
                default:
                    deviceType = "droid";
                    break;
            }

            // Not working !!!
            //#if __ANDROID__
            //            device = "Droid";
            //#endif

            var currentNamespace = string.Join(".", type.Namespace.Split('.').Take(2));
            var resource = string.Format(
                "{0}.{1}.{2}-{3}.{4}",
                currentNamespace,
                "Config",
                "config",
                deviceType,
                "xml"
            );

            //ConfigResponse configResponse = null;
            var response = await Task.Run(() =>
            {
                using (var stream = type.GetTypeInfo().Assembly.GetManifestResourceStream(resource))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        var doc = XDocument.Parse(reader.ReadToEnd());
                        //var doc = XDocument.Load(reader);
                        var configRes = new ConfigResponse();

                        configRes.Auth = (from ele in doc.Descendants("auth-config")
                                          select new
                                          {
                                              Key = ele.FirstAttribute.Value,
                                              Config = new AuthConfigResponse
                                              {
                                                  ClientId = ele.Descendants("client-id").FirstOrDefault()?.Value,
                                                  Scope = ele.Descendants("scope").FirstOrDefault()?.Value,
                                                  AuthorizeUrl = ele.Descendants("authorize-url").FirstOrDefault()?.Value,
                                                  RedirectUrl = ele.Descendants("redirect-url").FirstOrDefault()?.Value
                                              }
                                          }).ToDictionary(r => r.Key, r => r.Config);

                        //var auth = from ele in doc.Root.Elements()
                        //           where ele.Name == "auth"
                        //           select ele;

                        //var configRes = from ele in auth
                        //                select 

                        //var authConfig = doc.Element("auth");

                        /*configRes.Auth = auth.Elements().Select(a =>
                        {
                            var key = (a.HasAttributes) ? a.Attribute("id").Value : null;
                            AuthConfigResponse authConfigResponse;
                            if (key != null)
                            {
                                authConfigResponse = new AuthConfigResponse
                                {
                                    ClientId = a.Element("client-id").Value,
                                    Scope = a.Element("scope").Value,
                                    AuthorizeUrl = a.Element("authorize-url").Value,
                                    RedirectUrl = a.Element("redirect-url").Value
                                };

                                return new { Key = key, Config = authConfigResponse };
                            }

                            return null;
                        }).ToDictionary(r => r.Key, r => r.Config);*/

                        return configRes;
                    }
                }
            });

            return response;
        }
    }
}
