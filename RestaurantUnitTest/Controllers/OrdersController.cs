using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RestaurantUnitTest.Models;
using System.Data.SqlClient;

namespace RestaurantUnitTest.Controllers
{
    public class OrdersController : Controller
    {
        private RestdbEntities db = new RestdbEntities();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Customer);
            return View(orders.ToList());
        }


        // GET: Orders/Create 
        //just create order Automaticly
        public ActionResult Create(string customerPhone)
        {
            Customer customer = db.Customers.Find(customerPhone);
            if (customer != null)
            {
                //INit new order and set 
                Order order = new Order();
                order.Customer = customer;
                order.CustomerPhoneNumber = customer.PhoneNumber;
                order.TimeStamp = System.DateTime.Now;
                //add to db
                db.Orders.Add(order);
                db.SaveChanges();
                return View(order);
            }
            return View("Index","Home");
            
        }



        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
  
}
