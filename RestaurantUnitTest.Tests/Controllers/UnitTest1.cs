using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantUnitTest;
using RestaurantUnitTest.Controllers;


namespace RestaurantUnitTest.Tests.Controllers
{

    public class order
    {
       public string name { get; set; }


       public DateTime date

       { get; set; }

       public string familyName
       {
           get { return "safaie"; }
        
       }
       public int price { get; set;}

 
    }
    public class Item
    {
        public int price { get; set; }
        public string name { get; set; }
    }
   
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void firstTest()
        {
            order myorder = new order();
            myorder.name = "john";
            myorder.date = DateTime.Now;
            var st = myorder.familyName;
            Console.WriteLine("{0} {1} {2}", myorder.name, myorder.date,st);
            
        }
        public int total;
         [TestMethod]
        public void TotalTest()
        {
            List<Item> myList = new List<Item>();

            Item item1 = new Item();
            item1.name = "james";
            item1.price = 500;
            myList.Add(item1);
            Item item2 = new Item();
            item2.name = "jones";
            item2.price = 550;
            myList.Add(item2);
            Item item3 = new Item();
            item3.name = "Cale";
            item3.price = 700;
            myList.Add(item3);
         
            foreach (var i in myList)
            {
                var j = i.price;
                total += j;
            }

            Console.WriteLine("{0}",total);
         
        }
    }
}
