using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Windows;
using MessangerServer.Models;
using Newtonsoft.Json;

namespace MessangerServer.Controllers
{
    public class MessageController : ApiController
    {
        // GET: Message
        public IEnumerable<Message> Get()
        {
            List<Models.Message> message = new List<Models.Message>();
            Appdata.RefreshChanges();
            message = Appdata.Context.Message.ToList();
            return message;
        }


        public Message Get(int id)
        {
            return Appdata.Context.Message.FirstOrDefault(e => e.ID == id);
        }

        public List<Message> Get(int idUserSent, int idUserGet)
        {
            return Appdata.Context.Message.Where(e => e.IDUserSent == idUserSent & e.IDUserGet == idUserGet || e.IDUserSent == idUserGet & e.IDUserGet == idUserSent).ToList();
        }

        public HttpResponseMessage Post([FromBody] Message message)
        {
            try
            {
                Appdata.Context.Message.Add(message);
                Appdata.Context.SaveChanges();
                var request = Request.CreateResponse(HttpStatusCode.Created, message);
                request.Headers.Location = new Uri(Request.RequestUri +
                    message.ID.ToString());
                return request;
            }
             catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }


        }
    }
}