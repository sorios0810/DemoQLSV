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
    public class DMSVsController : Controller
    {
        private DemoDbConnect db = new DemoDbConnect();

        // GET: DMSVs
        public ActionResult Index()
        {
            var dMSVs = db.DMSVs.Include(d => d.DMKhoa);
            return View(dMSVs.ToList());
        }

        // GET: DMSVs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMSV dMSV = db.DMSVs.Find(id);
            if (dMSV == null)
            {
                return HttpNotFound();
            }
            return View(dMSV);
        }

        // GET: DMSVs/Create
        public ActionResult Create()
        {
            ViewBag.MaKhoa = new SelectList(db.DMKhoas, "MaKhoa", "TenKhoa");
            return View();
        }

        // POST: DMSVs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSV,HoSV,TenSV,Phai,NgaySinh,NoiSinh,MaKhoa,HocBong")] DMSV dMSV)
        {
            if (ModelState.IsValid)
            {
                db.DMSVs.Add(dMSV);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKhoa = new SelectList(db.DMKhoas, "MaKhoa", "TenKhoa", dMSV.MaKhoa);
            return View(dMSV);
        }

        // GET: DMSVs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMSV dMSV = db.DMSVs.Find(id);
            if (dMSV == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKhoa = new SelectList(db.DMKhoas, "MaKhoa", "TenKhoa", dMSV.MaKhoa);
            return View(dMSV);
        }

        // POST: DMSVs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSV,HoSV,TenSV,Phai,NgaySinh,NoiSinh,MaKhoa,HocBong")] DMSV dMSV)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dMSV).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKhoa = new SelectList(db.DMKhoas, "MaKhoa", "TenKhoa", dMSV.MaKhoa);
            return View(dMSV);
        }

        // GET: DMSVs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMSV dMSV = db.DMSVs.Find(id);
            if (dMSV == null)
            {
                return HttpNotFound();
            }
            return View(dMSV);
        }

        // POST: DMSVs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DMSV dMSV = db.DMSVs.Find(id);
            db.DMSVs.Remove(dMSV);
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
