using Microsoft.AspNetCore.Http;
namespace EntGuild.Models
{
    public class CartSession
    {
        private const string ProductsKey = "myproducts";

        private ISession session { get; set; }
        public CartSession(ISession session) => this.session = session;
        public void SetCart(List<Product> cartItems)
        {
            session.SetObject(ProductsKey, cartItems);
        }

        public List<Product> GetCartItems() =>
            session.GetObject<List<Product>>(ProductsKey) ?? new List<Product>();

        public void RemoveCartItem()
        {
            session.Remove(ProductsKey);
        }
    }
}
