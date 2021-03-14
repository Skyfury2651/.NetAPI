using ProjectAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace ProjectAPI.Controllers
{
    [RoutePrefix("api/Orders")]
    public class OrdersController : ApiController
    {
        AuthContext authContext = new AuthContext();

        [Authorize]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(Order.CreateOrders());
        }

        [Authorize]
        [Route("")]
        [HttpPost]
        public IHttpActionResult Store(Order order)
        {
            authContext.Orders.Add(order);
            authContext.SaveChanges();
            return Ok(order);
        }

        [Authorize]
        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult Detail(int id)
        {
            var order = authContext.Orders.Find(id);

            return Ok(order);
        }

        [Authorize]
        [Route("{id:int}")]
        [HttpPut]
        public IHttpActionResult Update(int id , Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order.OrderID)
            {
                return BadRequest();
            }

            authContext.Entry(order).State = EntityState.Modified;

            try
            {
                authContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(order);
        }

        [Authorize]
        [Route("{id:int}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var order = authContext.Orders.Find(id);
            authContext.Orders.Remove(order);
            try
            {
                authContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        private bool OrderExists(int id)
        {
            return authContext.Orders.Count(e => e.OrderID == id) > 0;
        }

    }
}