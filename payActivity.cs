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

namespace Project
{
    //[Activity(Label = "payActivity")]
    [Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/world")]
    public class payActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            RequestWindowFeature(Android.Views.WindowFeatures.ActionBar);
            // Set our view from the "main" layout resource
            

            this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            AddTab("PAYPAL", Resource.Drawable.ip, new pal());
            AddTab("CREDIT/DEBIT", Resource.Drawable.ic, new debit());

            SetContentView(Resource.Layout.tab);
        }

        void AddTab(string tabText, int iconResourceId, Fragment fragment)
        {
            var tab = this.ActionBar.NewTab();
            tab.SetText(tabText);
            tab.SetIcon(iconResourceId);

            // must set event handler for replacing tabs tab
            tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e)
            {

                e.FragmentTransaction.Replace(Resource.Id.fragmentContainer, fragment);
            };
            this.ActionBar.AddTab(tab);
        }
    }
}