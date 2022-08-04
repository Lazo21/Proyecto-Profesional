using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaTaller.Models;

namespace SistemaTaller.Controllers
{
    public class ReporteBitacora_IngresoController : Controller
    {
        private DB_A698ED_ericyamiEntities db = new DB_A698ED_ericyamiEntities();

        // GET: ReporteBitacora_Ingreso
        public ActionResult Index()
        {
            return View(db.Bitacora_Ingreso.ToList());
        }

        // GET: ReporteBitacora_Ingreso/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bitacora_Ingreso bitacora_Ingreso = db.Bitacora_Ingreso.Find(id);
            if (bitacora_Ingreso == null)
            {
                return HttpNotFound();
            }
            return View(bitacora_Ingreso);
        }

        // GET: ReporteBitacora_Ingreso/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReporteBitacora_Ingreso/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdBitacoraIngreso,Usuario,FechaHoraIngreso,FechaHoraSalida,TotalMinutos")] Bitacora_Ingreso bitacora_Ingreso)
        {
            if (ModelState.IsValid)
            {
                db.Bitacora_Ingreso.Add(bitacora_Ingreso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bitacora_Ingreso);
        }

        // GET: ReporteBitacora_Ingreso/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bitacora_Ingreso bitacora_Ingreso = db.Bitacora_Ingreso.Find(id);
            if (bitacora_Ingreso == null)
            {
                return HttpNotFound();
            }
            return View(bitacora_Ingreso);
        }

        // POST: ReporteBitacora_Ingreso/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdBitacoraIngreso,Usuario,FechaHoraIngreso,FechaHoraSalida,TotalMinutos")] Bitacora_Ingreso bitacora_Ingreso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bitacora_Ingreso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bitacora_Ingreso);
        }

        // GET: ReporteBitacora_Ingreso/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bitacora_Ingreso bitacora_Ingreso = db.Bitacora_Ingreso.Find(id);
            if (bitacora_Ingreso == null)
            {
                return HttpNotFound();
            }
            return View(bitacora_Ingreso);
        }

        // POST: ReporteBitacora_Ingreso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bitacora_Ingreso bitacora_Ingreso = db.Bitacora_Ingreso.Find(id);
            db.Bitacora_Ingreso.Remove(bitacora_Ingreso);
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
