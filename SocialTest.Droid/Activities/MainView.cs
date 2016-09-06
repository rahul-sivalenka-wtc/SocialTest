using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using MvvmCross.Droid.Views;

namespace SocialTest.Droid.Activities
{
    [Activity(Label = "SocialTest.Droid", MainLauncher = true, Icon = "@drawable/Icon")]
    public class MainView : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.Main);
        }
        //int count = 1;

        //protected override void OnCreate(Bundle bundle)
        //{
        //    base.OnCreate(bundle);

        //    // Set our view from the "main" layout resource
        //    SetContentView(Resource.Layout.Main);

        //    // Get our button from the layout resource,
        //    // and attach an event to it
        //    Button button = FindViewById<Button>(Resource.Id.MyButton);

        //    button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
        //}
    }
}

