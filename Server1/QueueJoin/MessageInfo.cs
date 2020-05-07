using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueJoin
{   [Serializable]
    class MessageInfo
    {
      public Groups group;
        public User user;
        public QueueJ queue;
        public int CodOperation;
        public int index;
        public string str;
    }
}
