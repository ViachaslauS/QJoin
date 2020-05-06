using System;
using Android.Content;
using Android.Widget;

namespace qJoin
{
    public class MyButton : Button
    {
        public int id;
        public MyButton(Context context, int id_): base(context)
        {
            id = id_;
        }
    }
}
