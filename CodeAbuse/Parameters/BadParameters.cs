using System;
using CodeAbuse.Parameters.Models;

namespace CodeAbuse.Parameters
{
    public class ShoppingService
    {
        private CartTransaction _cartTransaction;

        public void BeginTransaction(CartTransaction cartTransaction)
        {
            _cartTransaction = cartTransaction;
        }

        public void AddToCart(int cartId, int itemId, int quantity)
        {
            if (_cartTransaction == null)
            {
                throw new Exception("transaction must be initialized");
            }
        }
    }

    public class BadParametersExample
    {
        public void ExpectedProcedure()
        {
            var shoppingService = new ShoppingService();
            shoppingService.BeginTransaction(new CartTransaction {TransactionUri = "http://google.com/"});
            shoppingService.AddToCart(1, 2, 3);
        }

        public void AbusedProcedure()
        {
            var shoppingService = new ShoppingService();

            // This will throw an exception because we didn't call BeginTransaction first
            shoppingService.AddToCart(1, 2, 3);
        }
    }
}