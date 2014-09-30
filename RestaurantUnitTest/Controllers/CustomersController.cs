using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RestaurantUnitTest.Models;

namespace RestaurantUnitTest.Controllers
{
    public class CustomersController : Controller
    {
        //database 
        private RestdbEntities db = new RestdbEntities();

        // GET: Customers
        public ActionResult Index()
        {
          
            return View();
        }

        //returnlist of customers with creditCard info 

        public ActionResult myList()
        {
            var cus = db.Customers.Include(c => c.CreditCard).ToList();
            return View(cus);
        }


        /*
         * findCustomer function with view
         *Data coming from Ajax and return data to partial View same name
         * partial view for shwing our search resualt
         */
        public PartialViewResult findCustomer(string passedString)
        {
            int myPhone = Convert.ToInt32(passedString);
            
            //search query
            var customer = from c in db.Customers where c.PhoneNumber == myPhone select c;

            return PartialView(customer);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
       /*
        * Create customer and creditCard toghether to put into db 
        */ 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PhoneNumber,FistName,LastName,Address")] Customer customer ,
            [Bind(Include = "Id,CardName,CardType,CardNumber")] CreditCard creditCard)
        {

            if (ModelState.IsValid)
            {
                creditCard.Customer = customer;
                customer.CreditCard = creditCard;
                db.Customers.Add(customer);
                db.CreditCards.Add(creditCard);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
           return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PhoneNumber,FistName,LastName,Address")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
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
