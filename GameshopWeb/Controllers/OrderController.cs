using GameshopWeb.Db;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameshopWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private MyDbContext context;
        public OrderController(MyDbContext context)
        {
            this.context = context;
        }

        [HttpPost("")]
        public Order Create(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
            return order;
        }
    }
}
