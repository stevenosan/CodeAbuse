using System;
using System.Data.Common;

namespace CodeAbuse.Parameters
{
    class GoodParameters
    {
        public class BadParameters
        {
            public void DoSomeStuff()
            {
                var shoppingService = new ShoppingService();
                shoppingService.AddToCart(new CartTransaction { TransactionUri = "http://www.google.com" }, 1, 2, 3);
            }
        }

        public class ShoppingService
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

        public class CartTransaction
        {
            public string TransactionUri { get; set; }
        }
    }
}
