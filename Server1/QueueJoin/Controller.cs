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

        public static bool Authorization(User user)
        {
    

            User userTemp = db.Users.FirstOrDefault(x => x.Login == user.Login);
            if(userTemp == null)
            {
                return false;
            }
            if(user.Password == userTemp.Password)
            {
                return true;
            }
            return false;

        }
        public static bool CreateNewUser(User user)
        {

            User userTemp = db.Users.FirstOrDefault(x => x.Login == user.Login);
            if (userTemp != null)
            {
                return false;
            }

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
        public static bool CreateGroup(Groups group)
        {

            db.Groups.Add(group);
            db.SaveChanges();
            return true;
        }
        
        // login пользователя, котрый хочет подключиться к очереди, queueID - id очереди, к которой хочет подкючиться( его можно получить, из свойства пользователя Queues.Id), orderNum номер в очереди
        public static bool JoinToGroup(string nameOfGroup, User user)
        {
            db.Groups.FirstOrDefault(x => x.Name == nameOfGroup).Users.Add(user.Id, user);
                db.SaveChanges();
                return true;
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
            db.Users.FirstOrDefault(x => x.Login == login);
            
            foreach (var u in db.Users)
                if (u.Login == login)
                    return u.Id;

            return -1;
        }



        public static bool CreateQueue(Groups group, QueueJ queue)
        {
         
            db.Groups.FirstOrDefault(x => x.Name == group.Name).Queues.Add(queue);
            db.SaveChanges();


            return true;

        }

        public static bool JoinQueue(Groups group, User user, QueueJ queue, int numberOfPlace)
        {
            if (db.Groups.FirstOrDefault(x => x.Name == group.Name).Queues.FirstOrDefault(x => x == queue).Users.ContainsKey(numberOfPlace))
                return false;
            else
                db.Groups.FirstOrDefault(x => x.Name == group.Name).Queues.FirstOrDefault(x => x == queue).Users.Add(numberOfPlace, user);
            db.SaveChanges();
            return true;

        }

        public static int GetNumberOfUsersInGroup(int groupID)
        {
           return db.Groups.Find(groupID).Users.Count;
        }

        public static int GetNumberOfUsersInQueue(int groupID, int queueID)
        {
            return db.Groups.Find(groupID).GetQueue(queueID).Users.Count;
        }

        public static User GetUser(string login, string password)
        {
            int id = GetID(login);

            if (db.Users.Find(id).Password == password)
            {


                return db.Users.Find(id);
            }
            else return null;
        }


      

        public static UserQueueContext db = new UserQueueContext();
    }
}

