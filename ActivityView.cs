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
    [Activity(Label = "ActivityView")]
    public class ActivityView : Activity
    {
        TextView sourcedest;
        TextView costEstimate;
        EditText days;
        Spinner transportSpinner;

        Button cal;
        Button proceedPay;

        ArrayAdapter myArrayAdapter;
        string[] MeansOfTransport = { "Air", "Rail","Road","Water","Walk" };

        string sourceDestStr;
        string sourceStr;
        string myValue;

        int rate;

        int NoOfDays;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            rate = 0;

            // Create your application here
            SetContentView(Resource.Layout.pagetwo);

            sourcedest = FindViewById<TextView>(Resource.Id.sourceDest);
            costEstimate = FindViewById<TextView>(Resource.Id.Costtext);
            days = FindViewById<EditText>(Resource.Id.DaysNumber);
            proceedPay = FindViewById<Button>(Resource.Id.paymentBtn);
            transportSpinner = FindViewById<Spinner>(Resource.Id.transport);
            cal = FindViewById<Button>(Resource.Id.Calculate);

            //sourceStr = Intent.GetStringExtra("key").ToString();
            sourceDestStr = Intent.GetStringExtra("key2").ToString();


            NoOfDays = int.Parse(days.Text);

            string add = sourceDestStr;

            sourcedest.Text = add;

            myArrayAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, MeansOfTransport);
            myArrayAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            transportSpinner.Adapter = myArrayAdapter;

            transportSpinner.ItemSelected += TransportSpinner_ItemSelected;

            cal.Click += delegate {

                int da = Daysrate();
                rate = rate + da;
                costEstimate.Text = rate.ToString();
            };

            proceedPay.Click += delegate
            {
                var l = new Intent(this, typeof(payActivity));
                StartActivity(l);
            };
        }

        public int Daysrate()
        {
            int x = 0;
            if (NoOfDays >= 0 && NoOfDays <= 5)
            {
                x = 500; 
            }
            if (NoOfDays >= 0 && NoOfDays <= 4)
            {
                x = 400;
            }
            if (NoOfDays >= 0 && NoOfDays <= 3)
            {
                x =  300;
            }
            if (NoOfDays >= 0 && NoOfDays <= 2)
            {
                x = 200;
            }
            if (NoOfDays >= 0 && NoOfDays <= 1)
            {
                x = 100;
            }
            return x;
        }

        private void TransportSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            //throw new NotImplementedException();
            Spinner spinner = (Spinner)sender;
            //var myValue = spinner.GetItemAtPosition(e.Position);
            var value = spinner.GetItemAtPosition(e.Position);

            myValue = value.ToString();

            string toast = string.Format("You Selected {0}", myValue);

            Toast.MakeText(this, toast, ToastLength.Long).Show();

            int dayrate = Daysrate();

            if (myValue == "Air" )
            {
                rate = 1000+dayrate;
            }else if(myValue == "Rail")
            {
                rate = 500+dayrate;
            }else if (myValue == "Road")
            {
                rate = 250+dayrate;
            }else if (myValue == "Water")
            {
                rate = 125+dayrate;
            }else if(myValue == "Walk")
            {
                rate = 0+dayrate;
            }


            

        }
    }
}