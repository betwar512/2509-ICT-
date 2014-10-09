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
      
        public PartialViewResult Items(int? passedOrderId)
        {
            var items = db.Items.Include(i => i.Menu).GroupBy(t => t.MenuId);
            
            return PartialView(items);
        }

            /*
             * addToItem Method
             * passed objects = Order ,Item ,Quantity
             * Retunr (PartialView TO ajax in Order)
             */
         public PartialViewResult addToItems(string OrderId,string ItemId,string customer)
                {
             //recive data from Ajax in Order cshtml 
                    int orderId = Convert.ToInt32(OrderId);
                    int itemId = Convert.ToInt32(ItemId);

                    Int16 quantity = Convert.ToInt16(customer);
                    var order = db.Orders.Find(orderId);
                    var item = db.Items.Find(itemId);
                   
                        if (OrderId != null && ItemId != null && customer!=null)
                        {
                            //create OrderItem and add to db
                            OrderItem addItem = new OrderItem();
                            addItem.Order = order;
                            addItem.Item = item;
                            addItem.Quantity = quantity;
                            addItem.Timestamp = System.DateTime.Now;
                            addItem.UnitPrice = item.Price;
                            db.OrderItems.Add(addItem);
                            db.SaveChanges();
                            return PartialView(addItem);
                            
                        }
                        return PartialView();
                 
                   
                }
               

        // GET: Orders/Create 
        //just create order Automaticly
        public ActionResult Create(string customerPhone)
        {
            Customer customer = db.Customers.Find(customerPhone);
            var items = db.Items;
            //check data  return data
            if (customer != null)
            {
                //Init new order and set 
                Order order = new Order();
                order.Customer = customer;
                order.CustomerPhoneNumber = customer.PhoneNumber;
                order.TimeStamp = System.DateTime.Now;
                //add to db
                db.Orders.Add(order);
                db.SaveChanges();
                ViewBag.order = order;
                return View("Order",items);
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
