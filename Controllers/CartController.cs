using Microsoft.AspNetCore.Mvc;
using PasionMidtermStore.Data;
using PasionMidtermStore.Models;

namespace PasionMidtermStore.Controllers
{
    public class CartController : Controller
{
    
        private readonly ApplicationDbContext _db;
        public CartController(ApplicationDbContext db) { _db = db; }

        public IActionResult Index ()

        {
           var cartItems = _db.CartItems.ToList();
           return View(cartItems);
        }

        public IActionResult AddToCart(int id)
        {
            var product = _db.Products.Find(id);

            var cartItem = new CartItem
            {
                ProductId = product.Id,
                ProductName = product.Name,
                Price = product.Price,
                Quantity = 1
            };

            _db.CartItems.Add(cartItem);
            _db.SaveChanges();
             return RedirectToAction("Index");
        }
}
}
