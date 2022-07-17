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
    public class DMKhoasController : Controller
    {
        private DemoDbConnect db = new DemoDbConnect();

        // GET: DMKhoas
        public ActionResult Index()
        {
            return View(db.DMKhoas.ToList());
        }

        // GET: DMKhoas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMKhoa dMKhoa = db.DMKhoas.Find(id);
            if (dMKhoa == null)
            {
                return HttpNotFound();
            }
            return View(dMKhoa);
        }

        // GET: DMKhoas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DMKhoas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKhoa,TenKhoa")] DMKhoa dMKhoa)
        {
            if (ModelState.IsValid)
            {
                db.DMKhoas.Add(dMKhoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dMKhoa);
        }

        // GET: DMKhoas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMKhoa dMKhoa = db.DMKhoas.Find(id);
            if (dMKhoa == null)
            {
                return HttpNotFound();
            }
            return View(dMKhoa);
        }

        // POST: DMKhoas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKhoa,TenKhoa")] DMKhoa dMKhoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dMKhoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dMKhoa);
        }

        // GET: DMKhoas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMKhoa dMKhoa = db.DMKhoas.Find(id);
            if (dMKhoa == null)
            {
                return HttpNotFound();
            }
            return View(dMKhoa);
        }

        // POST: DMKhoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DMKhoa dMKhoa = db.DMKhoas.Find(id);
            db.DMKhoas.Remove(dMKhoa);
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
