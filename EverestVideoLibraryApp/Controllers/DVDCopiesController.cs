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
    public class DVDCopiesController : Controller
    {
        private Entities db = new Entities();

        // GET: DVDCopies
        public ActionResult Index()
        {
            var dVDCopies = db.DVDCopies.Include(d => d.DVDDetail);
            return View(dVDCopies.ToList());
        }

        // GET: DVDCopies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DVDCopy dVDCopy = db.DVDCopies.Find(id);
            if (dVDCopy == null)
            {
                return HttpNotFound();
            }
            return View(dVDCopy);
        }

        // GET: DVDCopies/Create
        public ActionResult Create()
        {
            ViewBag.DVDId = new SelectList(db.DVDDetails, "DVDId", "Title");
            return View();
        }

        // POST: DVDCopies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DCopyId,DVDId,Price,ReleasedDate,Description")] DVDCopy dVDCopy)
        {
            if (ModelState.IsValid)
            {
                db.DVDCopies.Add(dVDCopy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DVDId = new SelectList(db.DVDDetails, "DVDId", "Title", dVDCopy.DVDId);
            return View(dVDCopy);
        }

        // GET: DVDCopies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DVDCopy dVDCopy = db.DVDCopies.Find(id);
            if (dVDCopy == null)
            {
                return HttpNotFound();
            }
            ViewBag.DVDId = new SelectList(db.DVDDetails, "DVDId", "Title", dVDCopy.DVDId);
            return View(dVDCopy);
        }

        // POST: DVDCopies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DCopyId,DVDId,Price,ReleasedDate,Description")] DVDCopy dVDCopy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dVDCopy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DVDId = new SelectList(db.DVDDetails, "DVDId", "Title", dVDCopy.DVDId);
            return View(dVDCopy);
        }

        // GET: DVDCopies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DVDCopy dVDCopy = db.DVDCopies.Find(id);
            if (dVDCopy == null)
            {
                return HttpNotFound();
            }
            return View(dVDCopy);
        }

        // POST: DVDCopies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DVDCopy dVDCopy = db.DVDCopies.Find(id);
            db.DVDCopies.Remove(dVDCopy);
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
