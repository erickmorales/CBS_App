using FormSendMessage.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FormSendMessage.Controllers
{
    public class MensajeController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Add(Models.Request.MessageRequest model)
        {
            using (Models.messageWUPEntities db = new Models.messageWUPEntities())
            {
                var oMessage = new Models.Message();
                oMessage.Date = DateTime.Today;
                oMessage.ToNumber = model.ToNumber;
                oMessage.Message1 = model.Message1;
                db.Message.Add(oMessage);
                db.SaveChanges();

            }

            return Ok("Message sent");
        }


        [HttpGet]
        public IHttpActionResult Get()
        {
            List<Models.Request.MessageRequest> lst = new List<Models.Request.MessageRequest>();
            using (Models.messageWUPEntities db= new Models.messageWUPEntities())
            {
                lst = ( from d in db.Message
                       select new Models.Request.MessageRequest
                       {   
                           //Id = d.Id,
                           Date = d.Date,
                           ToNumber = d.ToNumber,
                           Message1 = d.Message1
                       }).ToList();
            }
            return Ok(lst);
        }



    }
}
