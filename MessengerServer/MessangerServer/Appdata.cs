using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessangerServer
{
    public class Appdata
    {
        public static Models.MessengerEntities1 Context { get; set; } = new Models.MessengerEntities1();

        public static void RefreshChanges() 
        {
            Context = new Models.MessengerEntities1();
        }
    }
}