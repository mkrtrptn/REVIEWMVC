using NavTech.DAL;
using NavTech.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using System.Security.Claims;
using System.Net.Http;

namespace NavTech.Controllers
{
    [Authorize]
    [RoutePrefix("api/order")]
    public class OrderController : ApiController
    {

        OrderContext db  =new OrderContext();

        static readonly IOrderRepository repository = new OrderRepository();

        //Admin Will get All The Records 
        [HttpGet]
        [Authorize(Roles ="admin")]
        [Route("allorders")]
        public IEnumerable<Order> GetOrders()
        {
            return repository.GetOrders();
        }

        
        
        //User Will get Their orders only
        [HttpGet]
        [Authorize(Roles = "user")]
        [Route("myorders/{id}")]
        public IHttpActionResult myOrders(int id)
        {
            var identity = (ClaimsIdentity)User.Identity;

            Order order = db.Orders.First(o => o.Id == id && o.Buyer == User.Identity.Name);
            if(order==null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return Ok(order);

        }


        







        //admin can checkout specific Order
        [HttpGet]
        [Authorize(Roles ="admin")]
        [Route("order/{id}")]
        public IHttpActionResult GetOrder(int id)
        {
            Order order = repository.GetOrder(id);
            if (order == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(order);
        }

        //Admin can Modify product
        [HttpPut]
        [Authorize(Roles ="admin")]
        [Route("update")]
        public IHttpActionResult PutOrder(Order order)
        {
            
            if (!ModelState.IsValid)
                return BadRequest("Not Valid Model");

            repository.Update(order);
            return Ok(order);

        }

        //User post The Order
        [HttpPost]
        [Route("add")]
        [Authorize(Roles ="user")]
        public IHttpActionResult PostOrder([FromBody] Order order)
        {
           


            var identity = (ClaimsIdentity)User.Identity;


            order.Buyer = identity.Name;
            order.Status = 1; // 1 placed , 2 approved,3 canceled,4 in delivery,5 completed

            if (order == null)
            {
                return NotFound();
            }

            repository.Add(order);

            //sendmail();

            return Ok(order);


          





        }



        //User Can Update Order
        [HttpPut]
        [Authorize(Roles = "user")]
        [Route("updatemyorder")]
        public IHttpActionResult PutmyOrder(Order order)
        {

            if (!ModelState.IsValid)
                return BadRequest("Not Valid Model");

            repository.Update(order);
            return Ok(order);

        }



        //user can Delete The Order
        [HttpDelete]
        [Route("delete/{id}")]
        public IHttpActionResult DeleteOrder(int id)
        {

            var identity = (ClaimsIdentity)User.Identity;

            Order od = repository.GetOrder(id);

            if (od == null || identity.Name != od.Buyer)
            {
                return BadRequest("Not Allowed");
            }

            repository.Delete(id);

            return Ok(id);

        }


        // Non Action Metod For Sending Mail
        // By Passing Values As Parameter to this We Send Mail To Customer
        // By Adding Credientials and mail server Detail in Mailsender Class 
        // And Call This Method In Post method

        public void sendmail()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var email = identity.Claims
                .Where(e => e.Type == ClaimTypes.Email)
                .Select(c => c.Value);
            MailSender.Sendmail();
        }





    }
}
