using System;
using System.Configuration;
using System.Web.Mvc;
using Twilio.AspNet.Common;
using Twilio.AspNet.Mvc;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML;
using Twilio.Types;



namespace apiTwilio.Controllers
{
    public class SmsController : TwilioController
    {
        
            public ActionResult SendSms()
            {
                string accountSid = ConfigurationManager.AppSettings["TwilioAccountSid"];
                string authToken = Environment.GetEnvironmentVariable("TwilioAuthToken");
                Twilio.TwilioClient.Init("AC146f11bb29f2b5ed200dfb899eb0b022", "eb776d4a1f410bd7813d357393e423e0");

                var to = new PhoneNumber(ConfigurationManager.AppSettings["MyPhoneNumber"]);
                var from = new PhoneNumber("+13608002455");

                
            var message = MessageResource.Create(
                    to: new Twilio.Types.PhoneNumber("+50375655714"),
                    from: new Twilio.Types.PhoneNumber("+13608002455"),
                    body: "Hello, thanks for check my code");

                
            
            return Content(message.Sid);
        }

     /*
        
        public ActionResult ReceiveSms()
        {
            var response = new MessagingResponse();
            response.Message("The Robots are coming! Head for the hills!");

            return TwiML(response);
        }
        */

        
     [HttpPost]
     public TwiMLResult Index(SmsRequest incomingMessage)
     {
         var messagingResponse = new MessagingResponse();
         messagingResponse.Message("The Robots are coming! Head for the hills!" + incomingMessage.Body);

         return TwiML(messagingResponse);
     }
     

    }
}