using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopWeb.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

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
            return context.Products.Include(p => p.Category).Include(p => p.Manufacturer).ToList();
        }

        [HttpGet("{id}")]
        public Product GetProduct(int id)
        {
            return context.Products.FirstOrDefault(p => p.ID == id);
        }

        [HttpPost("")]
        [Authorize]
        public Product Create(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return product;
        }

        [HttpPut("")]
        [Authorize]
        public Product Update(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();
            return product;
        }

        [HttpDelete("{id}")]
        [Authorize]
        public void Delete(int id)
        {
            context.Database.ExecuteSqlInterpolated($"DELETE FROM Product WHERE id = {id}");
        }

        [HttpGet("search")]
        public List<Product> Search(string name, decimal priceFrom, decimal priceTo)
        {
            return context.Products.Where( p => p.Name.Contains(name) || (p.Price >= priceFrom && p.Price <= priceTo)).ToList();
        }
    }
}
