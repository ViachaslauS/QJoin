
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

    [Activity(Label = "BtnActivity")]

    public class BtnActivity : Activity

    {
        static User user = new User();

        Button button1,button2;
        TextView textView1;
        LinearLayout linearLayout1;
        string str;
        private EventHandler btn3_click;
        public static Group group;
        static List<MyButton> btns = new List<MyButton>();
        public BtnActivity(Group gr)
        {
            group = gr;
        }
        public BtnActivity() { }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.BtnActivity);
            button1 = FindViewById<Button>(Resource.Id.button1);
            button2 = FindViewById<Button>(Resource.Id.button2);
            textView1 = FindViewById<TextView>(Resource.Id.textView1);
            LayoutParams lpView = new LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent);
            linearLayout1 = FindViewById<LinearLayout>(Resource.Id.linearLayout1);
            str = Intent.GetStringExtra("names");
            //Group group = (Group)Intent.GetSerializableExtra("Group");
            button1.Click += btn1_click;
            button2.Click += btn_click;
            // Create your application here
            //Bundle arguments = Intent.GetBundleExtra("Group");

            // if (arguments != null)
            {
                //Group group1 = (Group)arguments.GetSerializable("Group");
                //Group group = Intent.GetSerializableExtra
                textView1.Text = group.groupeName;

            }
            if (str != null)
            {
                Console.WriteLine("fdsfdg");
                user.groups.Add(new Group(str));
                btns.Add(new MyButton(this, btns.Count) { Text = str });
                Button b = new Button(this)
                {
                    Text = str
                };
                btns[btns.Count - 1].Click += Btn3_click;


                // btns.Add(b);
                // Adding buttons to view

                //linearLayout1.AddView(btns[btns.Count-1]);

                str = null;
            }
            for (int i = 0; i < btns.Count; i++)
            {

                btns[i].LayoutParameters = lpView;
                //Removing and adding buttons (kostyl)
                if (btns[i].Parent != null)
                    ((ViewGroup)btns[i].Parent).RemoveView(btns[i]);
                linearLayout1.AddView(btns[i]);
                //btns[i].Click += (sender,EventArgs) =>Btn3_click(sender,EventArgs,i-1);

            }
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

        private void btn1_click(object sender, System.EventArgs eventArgs)
        {

            btns.Clear();
            Intent intent = new Intent(this, typeof(MainActivity));
     
            StartActivity(intent);

        }
        private void btn_click(object sender, System.EventArgs eventArgs)
        {
            Intent intent = new Intent(this, typeof(Queue_Activity));

            StartActivity(intent);


        }
    }
}
