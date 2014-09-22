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
            Console.WriteLine("{0} {1}", myorder.name, myorder.date);
            Console.ReadLine();
        }
    }
}
