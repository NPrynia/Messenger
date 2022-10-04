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

    public class UserController : ApiController
    {
        public IEnumerable<User> Get()
        {
            List<Models.User> user = new List<Models.User>();
            Appdata.RefreshChanges();
            user = Appdata.Context.User.ToList();
            return user;
        }


        public User Get(int id)
        {
                return Appdata.Context.User.FirstOrDefault(e => e.ID == id);
        }

        public HttpResponseMessage Post([FromBody] User user)
        {
            try
            {
                Appdata.Context.User.Add(user);
                    Appdata.Context.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, user);
                    message.Headers.Location = new Uri(Request.RequestUri +
                        user.ID.ToString());
                    return message;
                
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Put([FromBody] User user)
        {
            try
            {
                var existingtUser = Appdata.Context.User.Where(s => s.ID == user.ID).FirstOrDefault();

                if (existingtUser != null)
                {
                    existingtUser.Name = user.Name;
                    existingtUser.Password = user.Password;
                    existingtUser.IsOnline = user.IsOnline;
                    existingtUser.ImageUser = user.ImageUser;

                    Appdata.Context.SaveChanges();
                }

                var message = Request.CreateResponse(HttpStatusCode.Created, user);
                message.Headers.Location = new Uri(Request.RequestUri +
                    user.ID.ToString());
                return message;

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }


           
                
        }


    }
}
