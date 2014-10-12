/*
*code Author Abbas H Safaie
*Created for Practice
*Project Name: Project Restaurant 
*Requested by Griffith university, Software Engineering semester 2 2014
*/

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
            var orderI = myOrder.OrderItems;
            //test 
            Assert.IsNotNull(orderI);
        }

        /*UnitTest
         * This test case provided to test calculation total for our Order  
         *we feeding $ item and quantity into the Array of Order Items and get data out of array and calculate total 
         *Caculate Order Total
         *inputs : item Prices { item1: item2: item3: item4: } Quantity {2}
         *OutPut:206
         */
        public void CaculateTotal()
        {
            //Order Object
            Order myOrder = new Order();
            //Items
            Item item1 = new Item();
            item1.Price = 25.6m;
            Item item2 = new Item();
            item2.Price = 25.7m;
            Item item3 = new Item();
            item2.Price = 25.8m;
            Item item4 = new Item();
            item4.Price = 25.9m;
            //OrderItems
            OrderItem item_order1 = addToItems(myOrder, item1);
            item_order1.Quantity=2;
            item_order1.UnitPrice=item1.Price;
            OrderItem item_order2 = addToItems(myOrder, item2);
             item_order2.Quantity=2;
            item_order2.UnitPrice=item2.Price;
            OrderItem item_order3 = addToItems(myOrder, item3);
            item_order3.Quantity=2;
            item_order3.UnitPrice=item3.Price;
            OrderItem item_order4 = addToItems(myOrder, item4);
            item_order4.Quantity=2;
            item_order4.UnitPrice=item4.Price;
            //Create Array 
            List<OrderItem> itemsTotal = new List<OrderItem> { item_order1, item_order2, item_order3, item_order4 };
         //retrive price * quantity and add to total 
            decimal total=0;
            foreach (var i in itemsTotal)
            {
                var price = i.UnitPrice * i.Quantity;
                total += price;
            }

            //Test
            Assert.AreEqual(206.0m, total);

        }
    }
}
