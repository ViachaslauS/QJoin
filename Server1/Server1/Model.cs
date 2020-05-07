using System.Collections.Generic;

namespace QueueJoin
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual List<Queue> Queues { get; set; }
        public User()
        {
            Queues = new List<Queue>();
        }
    }

    public class Queue
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual SortedDictionary<int, User> Users { get; set; }
        public Queue()
        {
            Users = new SortedDictionary<int, User>();
        }
    }
}
