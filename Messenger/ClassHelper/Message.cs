using Messager.ClassHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messager.ClassHelper
{
    public partial class Message
    {
        public int ID { get; set; }
        public string Message1 { get; set; }
        public int IDUserSent { get; set; }
        public int IDUserGet { get; set; }
        public System.DateTime TimeSent { get; set; }
        public byte[] Image { get; set; }

        public virtual User User { get; set; }

    }
}
