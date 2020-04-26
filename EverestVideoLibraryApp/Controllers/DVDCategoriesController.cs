using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EverestVideoLibraryApp.Models;

namespace EverestVideoLibraryApp.Controllers
{
    public class DVDCategoriesController : Controller
    {
        private Entities db = new Entities();

        // GET: DVDCategories
        public ActionResult Index()
        {
            return View(db.DVDCategories.ToList());
        }

        // GET: DVDCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DVDCategory dVDCategory = db.DVDCategories.Find(id);
            if (dVDCategory == null)
            {
                return HttpNotFound();
            }
            return View(dVDCategory);
        }

        // GET: DVDCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DVDCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DvdCatId,Category,License,Description")] DVDCategory dVDCategory)
        {
            if (ModelState.IsValid)
            {
                db.DVDCategories.Add(dVDCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dVDCategory);
        }

        // GET: DVDCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DVDCategory dVDCategory = db.DVDCategories.Find(id);
            if (dVDCategory == null)
            {
                return HttpNotFound();
            }
            return View(dVDCategory);
        }

        // POST: DVDCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DvdCatId,Category,License,Description")] DVDCategory dVDCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dVDCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dVDCategory);
        }

        // GET: DVDCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DVDCategory dVDCategory = db.DVDCategories.Find(id);
            if (dVDCategory == null)
            {
                return HttpNotFound();
            }
            return View(dVDCategory);
        }

        // POST: DVDCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DVDCategory dVDCategory = db.DVDCategories.Find(id);
            db.DVDCategories.Remove(dVDCategory);
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
