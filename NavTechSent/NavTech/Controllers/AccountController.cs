using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NavTech.Services;
using NavTech.Models;
using System.Security.Claims;

namespace NavTech.Controllers
{
    [Authorize]
    [RoutePrefix("api/user")]
    public class AccountController : ApiController
    {
        OrderContext db = new OrderContext();
      


        [HttpGet]
        [Route("admin/getusers")]
        [Authorize(Roles ="admin")]
        public IHttpActionResult GetUsr()
        {
           return Ok(db.Users.ToList()); 
        }

        [HttpGet]
        [Route("mydetail")]
        [Authorize(Roles ="admin,user")]
        public IHttpActionResult GetMyDetail()
        {


            var identity = (ClaimsIdentity)User.Identity;

            return Ok("Hello " + identity.Name );
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public IHttpActionResult Register(User usr)
        {
            User user = new User();
            user.Name = usr.Name;
            user.Email = usr.Email;
            user.Password = usr.Password;
            user.Role = usr.Role;
            
            db.Users.Add(user);
            db.SaveChanges();

            return Ok("Welcome " + user.Name +  "   Registration Successfull");
        }

        

    }
}
