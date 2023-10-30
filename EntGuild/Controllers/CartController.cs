using EntGuild.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApplication.Data;

namespace EntGuild.Controllers
{
    public class CartController : Controller
    {
        private EntGuildContext context;

        public CartController(EntGuildContext ctx) => context = ctx;

        [HttpGet]
        public ViewResult Index()
        {
            var session = new CartSession(HttpContext.Session);
            var model = new CartViewModel
            {
                CartItems = session.GetCartItems()
            };

            return View(model);
        }

        public ActionResult Add(Product product)
        {
            product = context.Products
                .Where(t => t.Id == product.Id)
                .FirstOrDefault() ?? new Product();

            var session = new CartSession(HttpContext.Session);
            var cart = session.GetCartItems();
            cart.Add(product);
            session.SetCart(cart);

            TempData["message"] = $"{product.Name} added to cart.";

            return RedirectToAction("Index", "Home");
        }

        public RedirectToActionResult Delete()
        {
            var session = new CartSession(HttpContext.Session);
            session.RemoveCartItem();
            TempData["message"] = "Cart cleared.";
            return RedirectToAction("Index", "Home");
        }
    }
}
