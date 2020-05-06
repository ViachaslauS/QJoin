using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using static Android.App.ActionBar;

namespace qJoin
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        static  User user= new User();
        Button button2,button1;
        LinearLayout linearLayout1;
        string str;
        private EventHandler btn_click;
        private EventHandler btn3_click;
        static List<MyButton> btns = new List<MyButton>();
    
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            button1 = FindViewById<Button>(Resource.Id.button1);
            button2 = FindViewById<Button>(Resource.Id.button2);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
              LayoutParams lpView = new LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent);
            linearLayout1 = FindViewById<LinearLayout>(Resource.Id.linearLayout1);
            str = Intent.GetStringExtra("name");
            if (str != null)
            {
                user.groups.Add(new Group(str));
                btns.Add(new MyButton(this,btns.Count) { Text = str });
                Button b = new Button(this)
                {
                    Text = str
                };
                btns[btns.Count-1].Click += Btn3_click;
                

                // btns.Add(b);
                // Adding buttons to view

                //linearLayout1.AddView(btns[btns.Count-1]);

                str = null;
            }
              for(int i=0;i<btns.Count;i++)
                {
                   
                    btns[i].LayoutParameters = lpView;
                    //Removing and adding buttons (kostyl)
                    if(btns[i].Parent!=null)
                        ((ViewGroup)btns[i].Parent).RemoveView(btns[i]);
                    linearLayout1.AddView(btns[i]);
                  //btns[i].Click += (sender,EventArgs) =>Btn3_click(sender,EventArgs,i-1);
            
                }
            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;
            button2.Click += btn2_click;
          
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }
             
            return base.OnOptionsItemSelected(item);
        }
      
        private void Btn3_click(object sender, EventArgs eventArgs)
        {
            //((Button)sender).Id
            //Intent intent = new Intent(this, typeof(BtnActivity));
            Intent intent = new Intent(this, new BtnActivity(user.groups[((MyButton)sender).id]).GetType());
            
            StartActivity(intent);
            Console.WriteLine("");
            // intent.PutExtra("Group", user.groups[index]);
            intent.PutExtra("a", 's');
        }
        private void btn2_click(object sender, EventArgs eventArgs)
        {
            Intent intent = new Intent(this, typeof(NewActivity));
            StartActivity(intent);

            Console.WriteLine("vfd");
        }
        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}

