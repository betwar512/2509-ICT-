/*
*code Author Abbas H Safaie
*Created for Practice
*Project Name: Project Restaurant 
*Requested by Griffith university, Software Engineering semester 2 2014
*/

using System;
using System.Data.Entity;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantUnitTest.Models;
using System.Linq;
using System.Data.SqlClient;

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
   
        /*
         * unit Test To create Order addtoIt and retrive object Name 
         */
        [TestMethod]
        public void Orders()
        {

            List<Item> items = new List<Item>();

            //Items 4 times
            for (int i = 0; i < 4; i++)
            {
                Item item = new Item();
                item.Name = string.Format("Item{0}", i);
                item.Price = 25+i;
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

            order.OrderItems = itemsInOrder;
            
                

            //retrive itemName and compare it to pass requirments
            var col = order.OrderItems;
            Decimal myTotal = new Decimal();
            foreach (var it in col)
            {
               myTotal=it.total();

                int i=0;
                string name = it.Item.Name;
                string compareName=string.Format("Item{0}",i);
                i++;

                
              //Test in unittest with exception for overload our method (inside Loop)
               UnitTestAssertException.Equals(name, compareName);
            }
        }

       
    
    }
}
