using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApiCapacitacion.Models;
using WebApiCapacitacion.Models.Entities;

namespace WebApiCapacitacion.Controllers
{
    public class CARGAS_FAMILIARESController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CARGAS_FAMILIARES
        public ActionResult Index()
        {
            var cARGAS_FAMILIARES = db.CARGAS_FAMILIARES.Include(c => c.EMPLEADOS);
            return View(cARGAS_FAMILIARES.ToList());
        }

        // GET: CARGAS_FAMILIARES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CARGAS_FAMILIARES cARGAS_FAMILIARES = db.CARGAS_FAMILIARES.Find(id);
            if (cARGAS_FAMILIARES == null)
            {
                return HttpNotFound();
            }
            return View(cARGAS_FAMILIARES);
        }

        // GET: CARGAS_FAMILIARES/Create
        public ActionResult Create()
        {
            ViewBag.EMP_ID = new SelectList(db.EMPLEADOS, "EMP_ID", "EMP_NOMBRE");
            return View();
        }

        // POST: CARGAS_FAMILIARES/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CARFAM_ID,CARFAM_NOMBRE,EMP_ID")] CARGAS_FAMILIARES cARGAS_FAMILIARES)
        {
            if (ModelState.IsValid)
            {
                db.CARGAS_FAMILIARES.Add(cARGAS_FAMILIARES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EMP_ID = new SelectList(db.EMPLEADOS, "EMP_ID", "EMP_NOMBRE", cARGAS_FAMILIARES.EMP_ID);
            return View(cARGAS_FAMILIARES);
        }

        // GET: CARGAS_FAMILIARES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CARGAS_FAMILIARES cARGAS_FAMILIARES = db.CARGAS_FAMILIARES.Find(id);
            if (cARGAS_FAMILIARES == null)
            {
                return HttpNotFound();
            }
            ViewBag.EMP_ID = new SelectList(db.EMPLEADOS, "EMP_ID", "EMP_NOMBRE", cARGAS_FAMILIARES.EMP_ID);
            return View(cARGAS_FAMILIARES);
        }

        // POST: CARGAS_FAMILIARES/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CARFAM_ID,CARFAM_NOMBRE,EMP_ID")] CARGAS_FAMILIARES cARGAS_FAMILIARES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cARGAS_FAMILIARES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EMP_ID = new SelectList(db.EMPLEADOS, "EMP_ID", "EMP_NOMBRE", cARGAS_FAMILIARES.EMP_ID);
            return View(cARGAS_FAMILIARES);
        }

        // GET: CARGAS_FAMILIARES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CARGAS_FAMILIARES cARGAS_FAMILIARES = db.CARGAS_FAMILIARES.Find(id);
            if (cARGAS_FAMILIARES == null)
            {
                return HttpNotFound();
            }
            return View(cARGAS_FAMILIARES);
        }

        // POST: CARGAS_FAMILIARES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CARGAS_FAMILIARES cARGAS_FAMILIARES = db.CARGAS_FAMILIARES.Find(id);
            db.CARGAS_FAMILIARES.Remove(cARGAS_FAMILIARES);
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
