using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LineNotify.Models;

namespace LineNotify.Controllers
{
    public class ExaminersController : Controller
    {
        private LineNotifyEntities db = new LineNotifyEntities();

        // GET: Examiners
        public ActionResult Index()
        {
            var examiners = db.Examiners.Include(e => e.Doctors);
            return View(examiners.ToList());
        }

        // GET: Examiners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examiners examiners = db.Examiners.Find(id);
            if (examiners == null)
            {
                return HttpNotFound();
            }
            return View(examiners);
        }

        // GET: Examiners/Create
        public ActionResult Create()
        {
            ViewBag.id = new SelectList(db.Doctors, "id", "patient_name");
            return View();
        }

        // POST: Examiners/Create
        // 若要免於大量指派 (overposting) 攻擊，請啟用您要繫結的特定屬性，
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,patient_id,patient_name,gender,test_id,test_name,test_value,date,doctor_name")] Examiners examiners)
        {
            if (ModelState.IsValid)
            {
                db.Examiners.Add(examiners);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id = new SelectList(db.Doctors, "id", "patient_name", examiners.id);
            return View(examiners);
        }

        // GET: Examiners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examiners examiners = db.Examiners.Find(id);
            if (examiners == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = new SelectList(db.Doctors, "id", "patient_name", examiners.id);
            return View(examiners);
        }

        // POST: Examiners/Edit/5
        // 若要免於大量指派 (overposting) 攻擊，請啟用您要繫結的特定屬性，
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,patient_id,patient_name,gender,test_id,test_name,test_value,date,doctor_name")] Examiners examiners)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examiners).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id = new SelectList(db.Doctors, "id", "patient_name", examiners.id);
            return View(examiners);
        }

        // GET: Examiners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examiners examiners = db.Examiners.Find(id);
            if (examiners == null)
            {
                return HttpNotFound();
            }
            return View(examiners);
        }

        // POST: Examiners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Examiners examiners = db.Examiners.Find(id);
            db.Examiners.Remove(examiners);
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
