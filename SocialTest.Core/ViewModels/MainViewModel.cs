using MvvmCross.Core.ViewModels;
using SocialTest.Core.Business.Manager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialTest.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        public string ButtonText { get { return "Test Button"; } }

        public IConfigManager ConfigManager { get; set; }

        public MainViewModel(IConfigManager configManager)
        {
            ConfigManager = configManager;
        }

        public override async void Start()
        {
            base.Start();
            var config = await ConfigManager.GetConfig();
        }
    }
}
