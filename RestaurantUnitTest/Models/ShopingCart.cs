using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantUnitTest.Models
{
    public partial class ShopingCart
    {
        //db instance
        RestdbEntities db = new RestdbEntities();

        string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";

        public static ShopingCart GetCart(HttpContextBase context)
        {
            var cart = new ShopingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }


        // Helper method to simplify shopping cart calls
        public static ShopingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        public void AddToCart(Item item)
        {
            // Get the matching cart and item instances
            var cartItem = db.Carts.SingleOrDefault(
                            c => c.CartId == ShoppingCartId
                            && c.ItemId == item.Id);

            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new Cart
                {
                    ItemId = item.Id,
                    CartId = ShoppingCartId,
                    Count = 1,
                    Timestamp = DateTime.Now
                };

                db.Carts.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart, then add one to the quantity
                cartItem.Count++;
            }

            // Save changes
            db.SaveChanges();
        }

        public int RemoveFromCart(int id)
        {
            // Get the cart
            var cartItem = db.Carts.Single(
                            cart => cart.CartId == ShoppingCartId
                            && cart.RecordId == id);

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    db.Carts.Remove(cartItem);
                }

                // Save changes
                db.SaveChanges();
            }

            return itemCount;
        }

        public void EmptyCart()
        {
            var cartItems = db.Carts.Where(cart => cart.CartId == ShoppingCartId);

            foreach (var cartItem in cartItems)
            {
                db.Carts.Remove(cartItem);
            }

            // Save changes
            db.SaveChanges();
        }

        public List<Cart> GetCartItems()
        {
            return db.Carts.Where(cart => cart.CartId == ShoppingCartId).ToList();
        }

        public int GetCount()
        {
            // Get the count of each item in the cart and sum them up
            int? count = (from cartItems in db.Carts
                          where cartItems.CartId == ShoppingCartId
                          select (int?)cartItems.Count).Sum();

            // Return 0 if all entries are null
            return count ?? 0;
        }

        public decimal GetTotal()
        {
            // Multiply Item price by count of that Item to get 
            // the current price for each of those Items in the cart
            // sum all Item price totals to get the cart total
            decimal? total = (from cartItems in db.Carts
                              where cartItems.CartId == ShoppingCartId
                              select (int?)cartItems.Count * cartItems.Item.Price).Sum();
            return total ?? decimal.Zero;
        }


        /////////////////////
        public int CreateOrder(Order order)
        {
            decimal orderTotal = 0;

            var cartItems = GetCartItems();

            // Iterate over the items in the cart, adding the OrderItem for each
            foreach (var item in cartItems)
            {
                var orderDetail = new OrderItem
                {
                    ItemId = item.ItemId,
                    OrderId = order.Id,
                    UnitPrice = item.Item.Price,
                    Quantity = item.Count
                };

                // Set the order total of the shopping cart
                orderTotal += (item.Count * item.Item.Price);

                db.OrderItems.Add(orderDetail);

            }

            // Set the order's total to the orderTotal count
           order.OrderTotal = orderTotal;

            // Save the order
            db.SaveChanges();

            // Empty the shopping cart
            EmptyCart();

            // Return the OrderId as the confirmation number
            return order.Id;
        }






        // We're using HttpContextBase to allow access to cookies.
        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();

                    // Send tempCartId back to client as a cookie
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }

            return context.Session[CartSessionKey].ToString();
        }
    }
}