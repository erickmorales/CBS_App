using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormSendMessage.Models.Request
{
    public class MessageRequest
    {
        
        public System.DateTime Date { get; set; }

        //[Required(ErrorMessage ="Please put a number to send message")]
        public string ToNumber { get; set; }

        //[Required(ErrorMessage = "Please put a message to send")]
        public string Message1 { get; set; }

    }
}