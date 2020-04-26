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
    public class ProducerDVDDetailsMappingsController : Controller
    {
        private Entities db = new Entities();

        // GET: ProducerDVDDetailsMappings
        public ActionResult Index()
        {
            var producerDVDDetailsMappings = db.ProducerDVDDetailsMappings.Include(p => p.DVDDetail).Include(p => p.Producer);
            return View(producerDVDDetailsMappings.ToList());
        }

        // GET: ProducerDVDDetailsMappings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProducerDVDDetailsMapping producerDVDDetailsMapping = db.ProducerDVDDetailsMappings.Find(id);
            if (producerDVDDetailsMapping == null)
            {
                return HttpNotFound();
            }
            return View(producerDVDDetailsMapping);
        }

        // GET: ProducerDVDDetailsMappings/Create
        public ActionResult Create()
        {
            ViewBag.DVDId = new SelectList(db.DVDDetails, "DVDId", "Title");
            ViewBag.ProducerId = new SelectList(db.Producers, "ProducerId", "Name");
            return View();
        }

        // POST: ProducerDVDDetailsMappings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "proDVDmapping,DVDId,ProducerId")] ProducerDVDDetailsMapping producerDVDDetailsMapping)
        {
            if (ModelState.IsValid)
            {
                db.ProducerDVDDetailsMappings.Add(producerDVDDetailsMapping);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DVDId = new SelectList(db.DVDDetails, "DVDId", "Title", producerDVDDetailsMapping.DVDId);
            ViewBag.ProducerId = new SelectList(db.Producers, "ProducerId", "Name", producerDVDDetailsMapping.ProducerId);
            return View(producerDVDDetailsMapping);
        }

        // GET: ProducerDVDDetailsMappings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProducerDVDDetailsMapping producerDVDDetailsMapping = db.ProducerDVDDetailsMappings.Find(id);
            if (producerDVDDetailsMapping == null)
            {
                return HttpNotFound();
            }
            ViewBag.DVDId = new SelectList(db.DVDDetails, "DVDId", "Title", producerDVDDetailsMapping.DVDId);
            ViewBag.ProducerId = new SelectList(db.Producers, "ProducerId", "Name", producerDVDDetailsMapping.ProducerId);
            return View(producerDVDDetailsMapping);
        }

        // POST: ProducerDVDDetailsMappings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "proDVDmapping,DVDId,ProducerId")] ProducerDVDDetailsMapping producerDVDDetailsMapping)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producerDVDDetailsMapping).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DVDId = new SelectList(db.DVDDetails, "DVDId", "Title", producerDVDDetailsMapping.DVDId);
            ViewBag.ProducerId = new SelectList(db.Producers, "ProducerId", "Name", producerDVDDetailsMapping.ProducerId);
            return View(producerDVDDetailsMapping);
        }

        // GET: ProducerDVDDetailsMappings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProducerDVDDetailsMapping producerDVDDetailsMapping = db.ProducerDVDDetailsMappings.Find(id);
            if (producerDVDDetailsMapping == null)
            {
                return HttpNotFound();
            }
            return View(producerDVDDetailsMapping);
        }

        // POST: ProducerDVDDetailsMappings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProducerDVDDetailsMapping producerDVDDetailsMapping = db.ProducerDVDDetailsMappings.Find(id);
            db.ProducerDVDDetailsMappings.Remove(producerDVDDetailsMapping);
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
