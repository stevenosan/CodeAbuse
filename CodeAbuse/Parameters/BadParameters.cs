using System;

namespace CodeAbuse.Parameters
{
    public class BadParameters
    {
        public void DoSomeStuff()
        {
            var shoppingService = new ShoppingService();
            var transaction = new CartTransaction {TransactionUri = "http://google.com/"};
            shoppingService.BeginTransaction(transaction);
            shoppingService.AddToCart(1, 2, 3);
        }
    }

    public class ShoppingService
    {
        private CartTransaction _cartTransaction;

        public void BeginTransaction(CartTransaction cartTransaction)
        {
            _cartTransaction = cartTransaction;
        }

        public void AddToCart(int cartId, int itemId, int quantity)
        {
            if ( _cartTransaction == null)
            {
                throw new Exception("transaction must be initialized");
            }
        }
    }

    public class CartTransaction
    {
        public string TransactionUri { get; set; }
    }
}
