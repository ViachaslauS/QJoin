using System;
using System.Collections.Generic;

namespace QueueJoin
{  [Serializable]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual List<Groups> Groups { get; set; }
        public User()
        {
            Groups = new List<Groups>();
        }
    }

    [Serializable]
    public class Groups
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public virtual List<QueueJ> Queues { get; set; }
        public virtual SortedDictionary<int, User> Users { get; set; }
        public Groups()
        {
            Users = new SortedDictionary<int, User>();
            Queues = new List<QueueJ>();
           
        }

        public int setQueueId()
        {
            if (Queues.Count == 0)
                return 1;
            return Queues.Count;
        }

        public QueueJ GetQueue(int ID)
        {
            return Queues[ID];
        }

    }
    [Serializable]
    public class QueueJ
    {
        public string Name { get; set; }
        public int num_places;
        public int Id { get; set; }

        public virtual SortedDictionary<int, User> Users { get; set; }

        public QueueJ()
        {
            Users = new SortedDictionary<int, User>();
            
        }
 
    }
}
