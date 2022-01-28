using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopWeb.Db;

namespace OnlineShopWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private MyDbContext context;
        public ProductController(MyDbContext context)
        {
            this.context = context;
        }

        [HttpGet("")]
        public List<Product> GetProducts() 
        {
            return context.Products.ToList();
        }
    }
}
