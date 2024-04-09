using System.Runtime.Serialization;

namespace a3_cprg_211_1.Test
{
    using a3_cprg211_1.Problem_Domain;
    using a3_cprg211_1.Utility;
    public static class SerializationHelper
    {
        /// <summary>
        /// Serializes (encodes) users
        /// </summary>
        /// <param name="users">List of users</param>
        /// <param name="fileName"></param>
        public static void SerializeUsers(ILinkedListADT users, string fileName)
        {
            List<User> userList = new List<User>();
            for (int i = 0; i < users.Count(); i++)
            {
                userList.Add(users.GetValue(i));
            }

            DataContractSerializer serializer = new DataContractSerializer(typeof(List<User>));
            using (FileStream stream = File.Create(fileName))
            {
                serializer.WriteObject(stream, userList);
            }
        }

        /// <summary>
        /// Deserializes (decodes) users
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>List of users</returns>
        public static ILinkedListADT DeserializeUsers(string fileName)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(List<User>));
            List<User> userList;

            using (FileStream stream = File.OpenRead(fileName))
            {
                userList = (List<User>)serializer.ReadObject(stream);
            }

            ILinkedListADT users = new SLL();

            foreach (User user in userList)
            {
                users.AddLast(user);
            }
            return users;
        }
    }
}
