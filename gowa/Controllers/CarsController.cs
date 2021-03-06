﻿using System;
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
        public ActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.LocationSortParm = string.IsNullOrEmpty(sortOrder) ? "location_desc" : "";
            ViewBag.PowerSortParm = string.IsNullOrEmpty(sortOrder) ? "power_desc" : "";
            var cars = db.Cars.Include(c => c.Model).Include(c => c.Workshop);
            switch (sortOrder)
            {
                case "name_desc":
                    cars = cars.OrderByDescending(c => c.Model.Name);
                    break;
                case "location_desc":
                    cars = cars.OrderByDescending(c => c.Workshop.Location);
                    break;
                case "power_desc":
                    cars = cars.OrderByDescending(c => c.HorsePower);
                    break;
                default:
                    cars = cars.OrderBy(c => c.Model.Name);
                    break;
            }
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
            ViewBag.ModelID = new SelectList(db.Models, "ModelID", "Name");
            ViewBag.WorkShopID = new SelectList(db.Workshops, "ID", "Location");
            return View();
        }

        // POST: Cars/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkShopID,ModelID,HorsePower")] Car car)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Cars.Add(car);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch(DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
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
            ViewBag.ModelID = new SelectList(db.Models, "ModelID", "Name", car.ModelID);
            ViewBag.WorkShopID = new SelectList(db.Workshops, "ID", "Location", car.WorkShopID);
            return View(car);
        }

        // POST: Cars/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var carToUpdate = db.Cars.Find(id);
            if (TryUpdateModel(carToUpdate, "",new string[] { "ModelID", "WorkShopID", "HorsePower" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch(DataException)
                {
                    ModelState.AddModelError("", "Unable to save changes.");
                }
            }
            ViewBag.ModelID = new SelectList(db.Models, "ModelID", "Name", carToUpdate.ModelID);
            ViewBag.WorkShopID = new SelectList(db.Workshops, "ID", "Location", carToUpdate.WorkShopID);
            return View(carToUpdate);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed";
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Car car = db.Cars.Find(id);
                db.Cars.Remove(car);
                db.SaveChanges();
            }
            catch(DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError= true });
            }

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
