
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

namespace qJoin
{
    [Activity(Label = "NewActivity")]
    public class NewActivity : Activity
    {
        TextView textView1;
        Button button1;
        EditText editText1;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.NewActivity);
           
            button1 = FindViewById<Button>(Resource.Id.button1);
            editText1 = FindViewById<EditText>(Resource.Id.editText1);
            button1.Click += btn_click;
        }
        private void btn_click(object sender, System.EventArgs eventArgs)
        {

            Intent intent = new Intent(this, typeof(MainActivity));
            intent.PutExtra("name", editText1.Text.ToString());
            StartActivity(intent);

        }
    }
}
