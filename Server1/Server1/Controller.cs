using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace QueueJoin
{
    public static class Controller
    {
        public static bool CreateNewUser(string login, string password, string name)
        {        
            if(GetID(login) != -1)
                return false;

            User user = new User { Login = login, Password = password, Name = name };
            db.Users.Add(user);
            db.SaveChanges();

            return true;
        }

    /*public static void ChangeUserName(string login, string name)
        {
            foreach (var u in db.Users)
                if (u.Login == login)
                {
                    u.UserName = name;
                    db.Entry(u).State = EntityState.Modified;
                    db.SaveChanges();
                }
        }
    }

    public static void ChangeUserPassword(string login, string password)
    {
        using (UserContext db = new UserContext())
        {
            foreach (var u in db.Users)
                if (u.Login == login)
                {
                    u.Password = password;
                    db.Entry(u).State = EntityState.Modified;
                    db.SaveChanges();
                }
        }
    }*/

    // login пользователя, котрый хочет создать очередь, queueName имя очереди, orderNum номер в очереди
    public static bool CreateQueue(string login, string queueName, int orderNum)
        {
            int id = GetID(login);

            if(id != -1)
            {
                Queue queue = new Queue { Name = queueName };
                queue.Users.Add(orderNum, db.Users.Find(id));
                db.Queues.Add(queue);
                db.Users.Find(id).Queues.Add(queue);
                db.SaveChanges();

                return true;
            }

            return false;
        }
        
        // login пользователя, котрый хочет подключиться к очереди, queueID - id очереди, к которой хочет подкючиться( его можно получить, из свойства пользователя Queues.Id), orderNum номер в очереди
        public static bool JoinToQueue(string login, int queueID, int orderNum)
        {
            int id = GetID(login);

            if(id != -1)
            {
                Queue queue = db.Queues.Find(queueID);
                queue.Users.Add(orderNum, db.Users.Find(id));
                db.Users.Find(id).Queues.Add(queue);

                db.SaveChanges();

                return true;
            }

            return false;
        }

        //public static bool LeaveQueue(string login, int queueID, int orderNum)
        //{
        //    using (UserContext db = new UserContext())
        //    {
        //        foreach (var u in db.Users)
        //            if (u.Login == login)
        //            {
        //                for (int i = 0; i < u.QueuesID.Count; i++)
        //                    if (u.QueuesID[i] == queueID) u.QueuesID[i] = 0;

        //                db.Queues.Find(queueID).QueueParticipants[orderNum] = null;

        //                db.Entry(u).State = EntityState.Modified;
        //                db.Entry(db.Queues.Find(queueID)).State = EntityState.Modified;
        //                db.SaveChanges();

        //                return true;
        //            }
        //        return false;
        //    }
        //}

        public static User ShowUserInfo(string login)
        {
            int id = GetID(login);
            
            if(id != -1)
                return  db.Users.Find(id);

            return null;
        }

        public static int GetID(string login)
        {
            if (db.Users.Find(1) == null)
                return -1;

            foreach (var u in db.Users)
                if (u.Login == login)
                    return u.Id;

            return -1;
        }

        public static UserQueueContext db = new UserQueueContext();
    }
}

