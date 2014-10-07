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
     
            //Array for items
            List<Item> items = new List<Item>();
            
            //Items 4 times
            for (int i = 0; i < 4; i++)
            {
                Item item = new Item();
                //add to list 
                items.Add(item);

            }


           
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
    [TestClass]
    class OrderCheck
    {
        [TestMethod]
        public void Orders()
        {



        }


    }
}
