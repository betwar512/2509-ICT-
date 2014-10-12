/*
*code Author Abbas H Safaie
*Created for Practice
*Project Name: Project Restaurant 
*Requested by Griffith university, Software Engineering semester 2 2014
*/


using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RestaurantUnitTest.Models;
using System.Web.Helpers;
using System.IO;

namespace RestaurantUnitTest.Controllers
{
    public class ItemsController : Controller
    {
        private RestdbEntities db = new RestdbEntities();

        // GET: Items
        //public PartialViewResult Items(string OrderId)
        //{
        //    var items = db.Items.Include(i => i.Menu).GroupBy(t=>t.MenuId);
        //    string or = OrderId;
        //    return PartialView(items);
        //}
     

        // GET: Items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            ViewBag.MenuId = new SelectList(db.Menus, "Id", "Name");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //TimeStamp didnt bind from view we Generate it here.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Price,MenuId")] Item item,HttpPostedFileBase file)
        {
            //image

            WebImage image = null;

            var newFileName = "";

            var imagePath = "";

            var imageThumbPath = "";

            image = WebImage.GetImageFromRequest();

            if (image != null)
            {
                //get Path add image 

                newFileName = Guid.NewGuid().ToString() + "_" +

                Path.GetFileName(image.FileName);
               
                imagePath =   @"~\images\" + newFileName;

                image.Save(imagePath);
                //first thumb 171*180
                imageThumbPath = (@"~\images\thumbs\" + newFileName);
                image.Resize(width: 171, height: 180, preserveAspectRatio: true,preventEnlarge: true);
                image.Save(imageThumbPath);

             WebImage secondImage = image.Clone();
             secondImage.Resize(width: 242, height: 200, preserveAspectRatio: true, preventEnlarge: true);
             string secondThumb = (@"~\images\second\"+newFileName) ;
             secondImage.Save(secondThumb);
               
            }

            if (ModelState.IsValid)
            {
                //add image path 
                item.Picture = newFileName;
                //add time stamp
                var time = DateTime.Now;
                item.TimeStamp = time;
                //add item and save it 
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            ViewBag.MenuId = new SelectList(db.Menus, "Id", "Name", item.MenuId);
            return View(item);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.MenuId = new SelectList(db.Menus, "Id", "Name", item.MenuId);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Price,Picture,MenuId,TimeStamp")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MenuId = new SelectList(db.Menus, "Id", "Name", item.MenuId);
            return View(item);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //find item
            Item item = db.Items.Find(id);
            //find OrderItem assosiated with Item 
       var orderItems=(from items in db.OrderItems 
                where items.ItemId == id 
                select items);
            //Delete Image assosiated with Item
            string imagepath = Request.MapPath("~/images/" + item.Picture);
            string thumbPath = Request.MapPath("~/images/thumbs/" + item.Picture);
            string thumbSecondPAth = Request.MapPath("~/images/second/" + item.Picture);
                   
            //condiotion for file exist
            if ( System.IO.File.Exists(imagepath))
            {
                System.IO.File.Delete(imagepath);
            }
            if(System.IO.File.Exists(thumbPath))
            {
                       System.IO.File.Delete(thumbPath);
                }
            if (System.IO.File.Exists(thumbSecondPAth))
            {
                System.IO.File.Delete(thumbSecondPAth);
            }
            foreach (var i in orderItems)
            {
                db.OrderItems.Remove(i);
            }
          //remove item from db
            db.Items.Remove(item);
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
