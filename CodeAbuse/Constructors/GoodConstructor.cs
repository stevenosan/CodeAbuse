using CodeAbuse.Constructors.Models;

namespace CodeAbuse.Constructors
{
    public class ShoppingServiceWithConstructor
    {
        private CartTransaction _cartTransaction;

        public ShoppingServiceWithConstructor(CartTransaction cartTransaction)
        {
            _cartTransaction = cartTransaction;
        }

        public void AddToCart(int cartId, int itemId, int quantity)
        {
            //add an item to the cart
        }
    }

    public class GoodConstructorExample
    {
        public void NewWayToCall()
        {
            var shoppingService = new ShoppingServiceWithConstructor(new CartTransaction {TransactionUri = "http://www.google.com"});
            shoppingService.AddToCart(1, 2, 3);
        }
    }
}