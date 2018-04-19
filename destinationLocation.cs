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
    [Activity(Label = "destination")]
    public class destinationLocation : Activity
    {
        EditText myTextValue;
        ListView myList;
        ArrayAdapter myAdapter;
        ArrayAdapter myAdapterCity;
        ArrayAdapter myAdapterCountry;
        List<string> collectionDest = new List<string>();
        List<string> city = new List<string>();
        List<string> country = new List<string>();

        Spinner myspinner;
        string[] myArray = { "City", "Country" };
        Button add;

        String myValue;

        String sourceValue;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here

            SetContentView(Resource.Layout.destination);

            //var view = inflater.Inflate(Resource.Layout.pageone, container, false);

            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            myTextValue = FindViewById<EditText>(Resource.Id.text);
            myList = FindViewById<ListView>(Resource.Id.myListId);
            add = FindViewById<Button>(Resource.Id.addButton);

            myspinner = FindViewById<Spinner>(Resource.Id.select);

            //collectionDest.Add(myTextValue.Text);
            //collectionDest.Add("Hyderabad");

            var arrayAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, myArray);
            arrayAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            myspinner.Adapter = arrayAdapter;

            myspinner.ItemSelected += Myspinner_ItemSelected;

            
            //string two = Intent.GetStringExtra("key").ToString();

            /* myAdapter = new ArrayAdapter<string>(this.Context, Android.Resource.Layout.SimpleListItem1, collectionDest);
             myList.SetAdapter(myAdapter);



             add.Click += delegate
             {
                 var item = myTextValue.Text;
                 collectionDest.Add(item);
                 myAdapter.Clear();
                 myAdapter.AddAll(collectionDest);
                 myAdapter.NotifyDataSetChanged();
             };


     */
            city.Add("Toronto");
            city.Add("Calgary");
            city.Add("Montreal");
            city.Add("Ottawa");

            country.Add("Canada");
            country.Add("India");
            country.Add("America");
            country.Add("Australia");

        }

        private void Myspinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            //throw new NotImplementedException();
            Spinner spinner = (Spinner)sender;
            //var myValue = spinner.GetItemAtPosition(e.Position);
            var value = spinner.GetItemAtPosition(e.Position);

            myValue = value.ToString();

            string toast = string.Format("You Selected {0}", myValue);

            Toast.MakeText(this, toast, ToastLength.Long).Show();


            if (myValue == "City")
            {
                myAdapterCity = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, city);
                myList.SetAdapter(myAdapterCity);

                add.Click += delegate
                {
                    var item = myTextValue.Text;
                    city.Add(item);
                    myAdapterCity.Clear();
                    myAdapterCity.AddAll(city);
                    myAdapterCity.NotifyDataSetChanged();
                };

                // searchItem.QueryTextChange += SearchItem_QueryTextChange;
                myList.ItemClick += MyList_ItemClick;



            }
            else if (myValue == "Country")
            {
                myAdapterCountry = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, country);
                myList.SetAdapter(myAdapterCountry);

                add.Click += delegate
                {
                    var item = myTextValue.Text;
                    country.Add(item);
                    myAdapterCountry.Clear();
                    myAdapterCountry.AddAll(country);
                    myAdapterCountry.NotifyDataSetChanged();
                };

                //searchItem.QueryTextChange += SearchItem_QueryTextChange1;

            }
        }

        private void MyList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //throw new NotImplementedException();
            sourceValue = Intent.GetStringExtra("key").ToString();
            String selectedFromList = (String)(myList.GetItemAtPosition(e.Position));

            String blank = " to ";
            String adding = String.Concat(String.Concat(sourceValue, blank), selectedFromList);

            var i = new Intent(this, typeof(ActivityView));
            i.PutExtra("key2", selectedFromList);
            StartActivity(i);

        }
    }
    }
