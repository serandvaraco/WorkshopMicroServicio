using APIShoppingCart.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIShoppingCart.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("ALL")]
    public class ShoppingCartController : Controller
    {
        readonly Models.ShoppingCartDataContext db;
        public ShoppingCartController(Models.ShoppingCartDataContext context)
        {
            db = context;
        }

        /// <summary>
        /// Adds the shopping cart.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        [HttpPost]
        public string AddShoppingCart([FromBody]Models.ShoppingCart value)
        {
            if (value == null)
                return "Objeto invalido";

            db.ShoppingCarts.Add(value);
            db.SaveChanges();
            return "OK";
        }

        /// <summary>
        /// Gets the shopping carts.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ShoppingCart> GetShoppingCarts() => db.ShoppingCarts;


    }
}
