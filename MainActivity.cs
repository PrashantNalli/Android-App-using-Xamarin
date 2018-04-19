using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Realms;

namespace Project
{
    [Activity(Label = "Project", MainLauncher = true)]
    public class MainActivity : Activity
    {
        EditText user;
        EditText password1;
        Button loginBtn;
        Button reg;
        TextView error;
        //Realm realmobj;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            //realmobj = Realm.GetInstance();
            user = FindViewById<EditText>(Resource.Id.userNameId);
            password1 = FindViewById<EditText>(Resource.Id.passWordId);
            loginBtn = FindViewById<Button>(Resource.Id.LoginBtnId);
            reg = FindViewById<Button>(Resource.Id.registerBtnId);
            error = FindViewById<TextView>(Resource.Id.error);

            loginBtn.Click += delegate
            {
                if (string.IsNullOrEmpty(user.Text))
                {
                    Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                    Android.App.AlertDialog alert = dialog.Create();
                    alert.SetTitle("error");
                    alert.SetMessage("INAVLID USERNAME OR PASSWORD");
                    alert.SetButton("ok", (c, ev) =>
                    {

                    });
                    alert.Show();

                }
                if (string.IsNullOrEmpty(password1.Text))
                {
                    Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                    Android.App.AlertDialog alert = dialog.Create();
                    alert.SetTitle("error");
                    alert.SetMessage("INVALID USERNAME OR PASSWORD");
                    alert.SetButton("ok", (c, ev) =>
                    {

                    });
                    alert.Show();
                }

                else
                {
                    loginBtn.Click += delegate
                    {
                        var wscreen = new Intent(this, typeof(startLocation));
                        StartActivity(wscreen);
                    };
                }

            };

            reg.Click += delegate
            {
                var regScreen = new Intent(this, typeof(SignUpActivity));
                StartActivity(regScreen);
            };

        }
    }
}