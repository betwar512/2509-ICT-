using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantUnitTest.Models;

namespace RestaurantUnitTest.Tests
{
    [TestClass]
    public class UnitTest1
    {
        //orderItems test 
        /*
         * create dummy items and add them to the orderItems then check the cound for our list 
         * This testCase created to check the model for each item adding into the 
         */
        [TestMethod]
        public void OrderItemsTest()
        {
            Customer cus = new Customer(); //{ Id = 1, FistName = "Fist", LastName = "LastName", Address = "ad"};
            //Items 
            Item item1 = new Item();
            Item item2 = new Item();
            Item item3 = new Item();
            Item item4 = new Item();

            //Array for items
            List<Item> items = new List<Item> { item1, item2, item3, item4 };
            //init new order
            Order order = new Order();
            //Array for our orderItems Objects
           List<OrderItem> itemsInOrder = new List<OrderItem>();
            
            //setting all the orderItems inside loop 
            for (int i = 0; i < items.Count; i++)
            {
            
                Item myItem = items[i];
                //Init OrderItem 
                OrderItem ordrItem = new OrderItem();
                ordrItem.Item = myItem;
                ordrItem.Order = order;
                ordrItem.Quantity = 3;
                ordrItem.UnitPrice = myItem.Price;
                ordrItem.OrderId = order.Id;
                ordrItem.ItemId = myItem.Id;
                //add the list 
                itemsInOrder.Add(ordrItem);
            }
            //test case count should be 4 
            Assert.AreEqual(itemsInOrder.Count,4);
         

           
        }
    }
}
