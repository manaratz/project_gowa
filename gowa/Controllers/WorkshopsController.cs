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
using gowa.ViewModels;

namespace gowa.Controllers
{
    public class WorkshopsController : Controller
    {
        private GarageContext db = new GarageContext();

        // GET: Workshops
        public ActionResult Index(int? id, string sortOrder)
        {
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.LocationSortParm = string.IsNullOrEmpty(sortOrder) ? "location_desc" : "";
            var viewModel = new WorkshopIndexData();
            switch(sortOrder)
            {
                case "name_desc":
                    viewModel.Workshops = db.Workshops
                        .Include(i => i.Car)
                        .OrderByDescending(i => i.Name);
                    break;
                case "location_desc":
                    viewModel.Workshops = db.Workshops
                        .Include(i => i.Car)
                        .OrderByDescending(i => i.Location);
                    break;
                default:
                    viewModel.Workshops = db.Workshops
                        .Include(i => i.Car)
                        .OrderBy(i => i.Name);
                    break;
            }

            if(id != null)
            {
                ViewBag.WorkshopID = id.Value;
                viewModel.Cars = viewModel.Workshops.Where(
                    i => i.ID == id.Value).Single().Car;
            }
            return View(viewModel);
        }

        // GET: Workshops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workshop workshop = db.Workshops.Find(id);
            if (workshop == null)
            {
                return HttpNotFound();
            }
            return View(workshop);
        }

        // GET: Workshops/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Workshops/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Location,Name")] Workshop workshop)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Workshops.Add(workshop);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch(DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View(workshop);
        }

        // GET: Workshops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workshop workshop = db.Workshops.Find(id);
            if (workshop == null)
            {
                return HttpNotFound();
            }
            return View(workshop);
        }

        // POST: Workshops/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var workshopToUpdate = db.Workshops.Find(id);
            if (TryUpdateModel(workshopToUpdate, "", new string[] { "Name","Location" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (DataException)
                {
                    ModelState.AddModelError("", "Unable to save changes.");
                }
            }
            return View(workshopToUpdate);
        }

        // GET: Workshops/Delete/5
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
            Workshop workshop = db.Workshops.Find(id);
            if (workshop == null)
            {
                return HttpNotFound();
            }
            return View(workshop);
        }

        // POST: Workshops/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Workshop workshop = db.Workshops.Find(id);
                db.Workshops.Remove(workshop);
                db.SaveChanges();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
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
