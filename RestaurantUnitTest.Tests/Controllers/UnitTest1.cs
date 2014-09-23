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
    //class Order created here 3 propery 
    public class order
    {
       public string name { get; set; }
       public DateTime date { get; set; }
       public int price { get; set; }
        //string without setter just getter 
       public string familyName
       {
           get { return "safaie"; }  
       }
  
    }

    //new object Item 
    public class Item
    {
        public int price { get; set; }
        public string name { get; set; }
    }
   
    [TestClass]
    public class UnitTest1
    {
        //test method just to Initilize object and give it property 

        [TestMethod]
        public void newObjectTest()
        {
            order myorder = new order();
            myorder.name = "john";
            myorder.date = DateTime.Now;
            var st = myorder.familyName;
            Console.WriteLine("{0} {1} {2}", myorder.name, myorder.date,st);
            
        }

        //total property to add all prices for Items together 
        public int total;

        /*methos for test tootal from our Array in c# 
         *method created 3 insted of object Item with seted properties 
         *create List (Array) and Add each item to Array 
         *Create foreach loop to het object out and add price to our total property 
         */
        
         [TestMethod]
        public void TotalTest()
        {
            List<Item> myList = new List<Item>();
             //item1
            Item item1 = new Item();
            item1.name = "james";
            item1.price = 500;
             //add to list 
            myList.Add(item1);
            //item2
             Item item2 = new Item();
            item2.name = "jones";
            item2.price = 550;
            //add to list 
            myList.Add(item2);
            //item3
             Item item3 = new Item();
            item3.name = "Cale";
            item3.price = 700;
            //add to list 
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
