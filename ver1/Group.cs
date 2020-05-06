using System;
using System.Collections.Generic;
using Android.Support.V7.View;
using Java.Interop;
using Java.IO;


namespace qJoin
{
    public class Group : Java.Lang.Object, ISerializable
    {
        List<Queue> gueues;
        public string groupeName;
        List<User> users;
        private int id;     //need to get from server
        

        public Group(string GroupeName)
        {
            groupeName = GroupeName;
        }

       
     

    }
}
