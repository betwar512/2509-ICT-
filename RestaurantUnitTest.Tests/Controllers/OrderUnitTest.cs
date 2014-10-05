using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantUnitTest.Models;
using System.Collections.Generic;

namespace RestaurantUnitTest.Tests.Controllers
{
    [TestClass]
    public class OrderUnitTest
    {
        public void init()
        {
       
            
        }
        



        [TestMethod]
        public void TestMethod1()
        {
            Customer customer1 = new Customer
            {
                Id = 1,
                FistName = "John",
                LastName = "Smith",
                Address = "1848Logan",
                CreditCard = null
            };

            Menu menu1 = new Menu
            {
                Id = 1,
                Name = "Menu1",
                Description = "Test Menu 1",
                Items = null
            };

            Item item1 = new Item
            {
                Id = 1,
                Description = "Item1",
                Name = "item1",
                Price = 25,
                Picture = null,
                TimeStamp = System.DateTime.Now,
                MenuId = 1,
                Menu = menu1
            };

            Item item2 = new Item
            {
                Id = 2,
                Description = "Item2",
                Name = "item2",
                Price = 26,
                Picture = null,
                TimeStamp = System.DateTime.Now,
                Menu = menu1,
                MenuId = 1
            };

            Item item3 = new Item
            {
                Id = 3,
                Description = "Item3",
                Name = "item3",
                Price = 27,
                Picture = null,
                TimeStamp = System.DateTime.Now,
                Menu = menu1,
                MenuId = 1
            };

            Item item4 = new Item
            {
                Id = 4,
                Description = "Item4",
                Name = "item4",
                Price = 28,
                Picture = null,
                TimeStamp = System.DateTime.Now,
                Menu = menu1,
                MenuId = 1
            };
         

            ICollection<Item> ye = menu1.Items;

            foreach (var c in ye)
            {
                string myString = c.Name;
            }
            Assert.IsNotNull(ye);
         
        }
    }
}
