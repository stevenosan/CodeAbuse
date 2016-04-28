using CodeAbuse.Parameters.Models;

namespace CodeAbuse.Parameters
{
    public class ShoppingServiceWithParameters
    {
        private CartTransaction _cartTransaction;

        public void BeginTransaction(CartTransaction cartTransaction)
        {
            _cartTransaction = cartTransaction;
        }

        public void AddToCart(CartTransaction transaction, int cartId, int itemId, int quantity)
        {
            //add an item to the cart
        }
    }

    public class GoodParametersExample
    {
        public void NewWayToCall()
        {
            var shoppingService = new ShoppingServiceWithParameters();
            shoppingService.AddToCart(new CartTransaction {TransactionUri = "http://www.google.com"}, 1, 2, 3);
        }
    }
}