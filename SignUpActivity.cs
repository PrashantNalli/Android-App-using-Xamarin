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
using Realms;

namespace Project
{
    [Activity(Label = "Activity3")]
    public class SignUpActivity : Activity
    {
        EditText FirstName;
        EditText LastName;
        EditText email;
        EditText Password;
        Button reg1;

       // public Realm realmobj1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.signup);
            // Create your application here

            FirstName = FindViewById<EditText>(Resource.Id.firstNameId);
            LastName = FindViewById<EditText>(Resource.Id.lastNameId);
            Password = FindViewById<EditText>(Resource.Id.passWordId);
            email = FindViewById<EditText>(Resource.Id.emailId);

            reg1 = FindViewById<Button>(Resource.Id.submitId);
            reg1.Click += delegate
            {
                var l = new Intent(this, typeof(MainActivity));
                StartActivity(l);

            };

        }

        
    }
}