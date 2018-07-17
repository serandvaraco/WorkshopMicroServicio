using Microsoft.EntityFrameworkCore;

namespace APIShoppingCart.Models
{
    public class ShoppingCartDataContext : DbContext
    {
        public ShoppingCartDataContext(DbContextOptions<ShoppingCartDataContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

    }
}
