using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIShoppingCart.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIShoppingCart.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        readonly Models.ShoppingCartDataContext context;

        public ProductsController(Models.ShoppingCartDataContext context)
        {
            this.context = context;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return context.Products.ToArray();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return context.Products.FirstOrDefault(x => x.Id == id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Product value)
        {
            context.Products.Add(value);
            context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
