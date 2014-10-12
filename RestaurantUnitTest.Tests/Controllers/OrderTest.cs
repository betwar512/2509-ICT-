using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantUnitTest.Models;
using System.Collections.Generic;


namespace RestaurantUnitTest.Tests.Controllers
{
    [TestClass]
    public class OrderTest
    {
        Order myOrder = new Order();
        OrderItem orderItem = new OrderItem();
        
      




        [TestMethod]
        public void TestMethod1()
        {
            //myCustomer 
            Customer myCustomer = new Customer {Id = 1,
                FistName = "test1",
                LastName = "lastName2" ,
                PhoneNumber = 0428210335,
                Address="test4",
                CreditCard=null};
                 //Item
           RestaurantUnitTest.Models.Item myItem=new RestaurantUnitTest.Models.Item{Id=1,Name="item1",Price=25};
            orderItem.Id = 1;
            orderItem.Item = myItem;
            orderItem.ItemId=myItem.Id;
            orderItem.Qnt = 2;
            //myOrder
            myOrder.Customer = myCustomer;
            myOrder.CustomerId = myCustomer.Id;
            myOrder.Id = 1;
            //add to order Items
            myOrder.OrderItems.Add(orderItem);
            myCustomer.Orders.Add(myOrder);
        
        }
    }
}
