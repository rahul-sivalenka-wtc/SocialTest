using MvvmCross.Core.ViewModels;
using SocialTest.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialTest.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            this.RegisterAppStart<MainViewModel>();
        }
    }
}
