using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DemoQLSV.Models;

namespace DemoQLSV.Controllers
{
    public class DMMHsController : Controller
    {
        private DemoDbConnect db = new DemoDbConnect();

        // GET: DMMHs
        public ActionResult Index()
        {
            return View(db.DMMHs.ToList());
        }

        // GET: DMMHs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMMH dMMH = db.DMMHs.Find(id);
            if (dMMH == null)
            {
                return HttpNotFound();
            }
            return View(dMMH);
        }

        // GET: DMMHs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DMMHs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaMH,TenMH,SoTiet")] DMMH dMMH)
        {
            if (ModelState.IsValid)
            {
                db.DMMHs.Add(dMMH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dMMH);
        }

        // GET: DMMHs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMMH dMMH = db.DMMHs.Find(id);
            if (dMMH == null)
            {
                return HttpNotFound();
            }
            return View(dMMH);
        }

        // POST: DMMHs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaMH,TenMH,SoTiet")] DMMH dMMH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dMMH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dMMH);
        }

        // GET: DMMHs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMMH dMMH = db.DMMHs.Find(id);
            if (dMMH == null)
            {
                return HttpNotFound();
            }
            return View(dMMH);
        }

        // POST: DMMHs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DMMH dMMH = db.DMMHs.Find(id);
            db.DMMHs.Remove(dMMH);
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
