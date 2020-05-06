
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
using static Android.App.ActionBar;

namespace qJoin
{
    [Activity(Label = "Queue_Activity")]
    public class Queue_Activity : Activity
    {
        Button button1, button2;
        EditText editText1;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Queue_Activity);
            button1 = FindViewById<Button>(Resource.Id.button1);
            button2 = FindViewById<Button>(Resource.Id.button2);
            editText1 = FindViewById<EditText>(Resource.Id.editText1);
            button1.Click += btn_click;
            button2.Click += btn1_click;

            // Create your application here
        }
        private void btn_click(object sender, System.EventArgs eventArgs)
        {
            Intent intent = new Intent(this, typeof(BtnActivity));
            intent.PutExtra("names", editText1.Text.ToString());
            StartActivity(intent);


        }
        private void btn1_click(object sender, System.EventArgs eventArgs)
        {
            Intent intent = new Intent(this, typeof(BtnActivity));
           
            StartActivity(intent);


        }
    }
}
