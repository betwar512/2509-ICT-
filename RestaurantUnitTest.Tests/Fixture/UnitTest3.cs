using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantUnitTest.Models;
using System.Collections.Generic;

namespace RestaurantUnitTest.Tests.Fixture
{
    [TestClass]
    public class UnitTest3
    {

        public OrderItem addToItems(Order order, Item item)
        {
            List<OrderItem> myOrderItems = new List<OrderItem>();
            OrderItem addItem = new OrderItem();
            addItem.Order = order;
            addItem.Item = item;

            return addItem;

        }

        //bod item and order with OrderItem

        [TestMethod]
        public void AddItemToOrder()
        {
            Order myOrder = new Order();

            Item item1 = new Item();
            Item item2 = new Item();
            Item item3 = new Item();
            Item item4 = new Item();

            OrderItem item_order1 = addToItems(myOrder, item1);
            OrderItem item_order2 = addToItems(myOrder, item2);
            OrderItem item_order3 = addToItems(myOrder, item3);
            OrderItem item_order4 = addToItems(myOrder, item4);

            List<OrderItem> itemsTotal = new List<OrderItem> {item_order1,item_order2,item_order3,item_order4 };
            myOrder.OrderItems = itemsTotal;
            //test 
            Assert.IsNotNull(myOrder);
        }
    }
}
