using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAbuse.Constructors
{
    class GoodConstructor
    {
        public class BadParameters
        {
            public void DoSomeStuff()
            {
                var shoppingService = new ShoppingService(new CartTransaction { TransactionUri = "http://www.google.com" });
                shoppingService.AddToCart(1, 2, 3);
            }
        }

        public class ShoppingService
        {
            private CartTransaction _cartTransaction;

            public ShoppingService(CartTransaction cartTransaction)
            {
                _cartTransaction = cartTransaction;
            }

            public void AddToCart(int cartId, int itemId, int quantity)
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
