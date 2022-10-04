using Messager.ClassHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messager.ClassHelper
{
    public partial class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public byte[] ImageUser { get; set; }
        public bool IsOnline { get; set; }

    }
   
}
