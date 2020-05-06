using System;
using System.Collections.Generic;
using Java.IO;

namespace qJoin
{
    public class User //: ISerializable
    {
        public List<Group> groups;
        public User()
        {
            groups = new List<Group>();
        }
        public string name;
        public string login, password;
       
    }
}
