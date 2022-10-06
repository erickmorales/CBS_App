using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppSendMessage.Models.Request
{
    public class MessageRequest
    {
        public System.DateTime Date { get; set; }
        public string ToNumber { get; set; }
        public string Message1 { get; set; }
    }
}
