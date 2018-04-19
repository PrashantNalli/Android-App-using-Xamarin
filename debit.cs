using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Project
{
    class debit : Fragment
    {
        EditText e1;
        EditText e2;
        EditText e3;
        EditText e4;
        Button p;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Project.Resource.Layout.layout1, container, false);
            e1 = view.FindViewById<EditText>(Resource.Id.cname);
            e2 = view.FindViewById<EditText>(Resource.Id.number);
            e3 = view.FindViewById<EditText>(Resource.Id.expire);
            e4 = view.FindViewById<EditText>(Resource.Id.cvv);
            p = view.FindViewById<Button>(Resource.Id.pay);

            p.Click += delegate
            {
                Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this.Context);
                Android.App.AlertDialog alert = dialog.Create();
                alert.SetTitle("Thank you");
                alert.SetMessage("Hope we see you again");
                alert.SetButton("ok", (c, ev) =>
                {

                });
                alert.Show();
            };
            return view;
        }

        private void Listnames_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Toast.MakeText(this.Context, e.Position, ToastLength.Long).Show();
        }

    }
}