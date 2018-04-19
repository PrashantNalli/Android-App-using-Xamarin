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
    class pal : Fragment
    {

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Project.Resource.Layout.paypal, container, false);


            return view;
        }

        private void Listnames_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Toast.MakeText(this.Context, e.Position, ToastLength.Long).Show();
        }
    }
}
