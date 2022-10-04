using Messager.ClassHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;


namespace Messager.ClassHelper
{
    class ApiHelper
    {
        public static List<User> getAllUser()
        {

            WebRequest request = WebRequest.Create("https://localhost:44317/api/User");
            request.Method = "Get";
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string jsonUser = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<List<User>>(jsonUser);
        }

        public static List<Message> getMessage(int idUserSent,int idUserGet)
        {
            WebRequest request = WebRequest.Create($"https://localhost:44317/api/Message?idUserSent={idUserSent}&idUserGet={idUserGet}");
            request.Method = "Get";
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string jsonMessage = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<List<Message>>(jsonMessage);
        }

    }
}
