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
    public class LoansController : Controller
    {
        private Entities db = new Entities();

        // GET: Loans
        public ActionResult Index()
        {
            var loans = db.Loans.Include(l => l.DVDCopy).Include(l => l.Member);
            return View(loans.ToList());
        }

        // GET: Loans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loan loan = db.Loans.Find(id);
            if (loan == null)
            {
                return HttpNotFound();
            }
            return View(loan);
        }

        // GET: Loans/Create
        public ActionResult Create()
        {
            ViewBag.DCopyId = new SelectList(db.DVDCopies, "DCopyId", "Price");
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "FirstName");
            return View();
        }

        // POST: Loans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LoanId,MemberId,DCopyId,IssuedDate,DueDate,ReturnedDate,DueAmount,FineAmount")] Loan loan)
        {
            if (ModelState.IsValid)
            {
                db.Loans.Add(loan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DCopyId = new SelectList(db.DVDCopies, "DCopyId", "Price", loan.DCopyId);
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "FirstName", loan.MemberId);
            return View(loan);
        }

        // GET: Loans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loan loan = db.Loans.Find(id);
            if (loan == null)
            {
                return HttpNotFound();
            }
            ViewBag.DCopyId = new SelectList(db.DVDCopies, "DCopyId", "Price", loan.DCopyId);
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "FirstName", loan.MemberId);
            return View(loan);
        }

        // POST: Loans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LoanId,MemberId,DCopyId,IssuedDate,DueDate,ReturnedDate,DueAmount,FineAmount")] Loan loan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DCopyId = new SelectList(db.DVDCopies, "DCopyId", "Price", loan.DCopyId);
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "FirstName", loan.MemberId);
            return View(loan);
        }

        // GET: Loans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loan loan = db.Loans.Find(id);
            if (loan == null)
            {
                return HttpNotFound();
            }
            return View(loan);
        }

        // POST: Loans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Loan loan = db.Loans.Find(id);
            db.Loans.Remove(loan);
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
