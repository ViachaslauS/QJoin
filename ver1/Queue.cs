using System;
using System.Runtime.Serialization;

namespace qJoin
{
    public class Queue : ISerializable
    {
        int num_places;
        User[] users;
        


        public Queue()
        {
            //users = new User[num_places];
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
