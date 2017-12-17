using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using gowa.DAL;
using gowa.Models;

namespace gowa.Controllers
{
    public class CarsController : Controller
    {
        private GarageContext db = new GarageContext();

        // GET: Cars
        public ActionResult Index()
        {
            var cars = db.Cars.Include(c => c.Brand).Include(c => c.Model).Include(c => c.Workshop);
            return View(cars.ToList());
        }

        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            ViewBag.BrandID = new SelectList(db.Brands, "ID", "Name");
            ViewBag.ModelID = new SelectList(db.Models, "ModelID", "Name");
            ViewBag.WorkShopID = new SelectList(db.Workshops, "ID", "Location");
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BrandID,WorkShopID,ModelID,HorsePower")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrandID = new SelectList(db.Brands, "ID", "Name", car.BrandID);
            ViewBag.ModelID = new SelectList(db.Models, "ModelID", "Name", car.ModelID);
            ViewBag.WorkShopID = new SelectList(db.Workshops, "ID", "Location", car.WorkShopID);
            return View(car);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandID = new SelectList(db.Brands, "ID", "Name", car.BrandID);
            ViewBag.ModelID = new SelectList(db.Models, "ModelID", "Name", car.ModelID);
            ViewBag.WorkShopID = new SelectList(db.Workshops, "ID", "Location", car.WorkShopID);
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BrandID,WorkShopID,ModelID,HorsePower")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandID = new SelectList(db.Brands, "ID", "Name", car.BrandID);
            ViewBag.ModelID = new SelectList(db.Models, "ModelID", "Name", car.ModelID);
            ViewBag.WorkShopID = new SelectList(db.Workshops, "ID", "Location", car.WorkShopID);
            return View(car);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
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
