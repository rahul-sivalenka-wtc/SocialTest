using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using SocialTest.Core;
using MvvmCross.Platform;
using SocialTest.Core.Business.Service;
using SocialTest.Core.Business.Service.Interfaces;
using SocialTest.Core.Business.Manager.Interfaces;
using SocialTest.Core.Business.Manager;
using SocialTest.Core.Models;

namespace SocialTest.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override void InitializeIoC()
        {
            base.InitializeIoC();

            Mvx.ConstructAndRegisterSingleton<IConfigService, ConfigService>();
            Mvx.ConstructAndRegisterSingleton<IConfigManager, ConfigManager>();
            Mvx.Resolve<IConfigManager>().Device = Device.ANDROID;
        }
    }
}