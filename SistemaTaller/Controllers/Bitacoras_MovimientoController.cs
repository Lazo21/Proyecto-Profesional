﻿using System;
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
    public class Bitacoras_MovimientoController : Controller
    {
        private DB_A698ED_ericyamiEntities db = new DB_A698ED_ericyamiEntities();

        // GET: Bitacoras_Movimiento
        public ActionResult Index(String BuscarBM)
        {
            try
            {
                var bicmov = from s in db.Bitacora_Movimiento select s;
                if (!String.IsNullOrEmpty(BuscarBM))
                {
                    bicmov = bicmov.Where(j => j.Usuario.Contains(BuscarBM) || j.TipoMovimiento.Contains(BuscarBM) || j.DetalleMovimiento.Contains(BuscarBM));
                    return View(bicmov.ToList());
                }
                return View(db.Bitacora_Movimiento.ToList());

            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }
        // GET: Bitacoras_Movimiento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bitacora_Movimiento bitacora_Movimiento = db.Bitacora_Movimiento.Find(id);
            if (bitacora_Movimiento == null)
            {
                return HttpNotFound();
            }
            return View(bitacora_Movimiento);
        }

        // GET: Bitacoras_Movimiento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bitacoras_Movimiento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdBitacoraMovimiento,Usuario,FechaHoraMovimiento,TipoMovimiento,DetalleMovimiento,IdRef")] Bitacora_Movimiento bitacora_Movimiento)
        {
            if (ModelState.IsValid)
            {
                db.Bitacora_Movimiento.Add(bitacora_Movimiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bitacora_Movimiento);
        }

        // GET: Bitacoras_Movimiento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bitacora_Movimiento bitacora_Movimiento = db.Bitacora_Movimiento.Find(id);
            if (bitacora_Movimiento == null)
            {
                return HttpNotFound();
            }
            return View(bitacora_Movimiento);
        }

        // POST: Bitacoras_Movimiento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdBitacoraMovimiento,Usuario,FechaHoraMovimiento,TipoMovimiento,DetalleMovimiento,IdRef")] Bitacora_Movimiento bitacora_Movimiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bitacora_Movimiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bitacora_Movimiento);
        }

        // GET: Bitacoras_Movimiento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bitacora_Movimiento bitacora_Movimiento = db.Bitacora_Movimiento.Find(id);
            if (bitacora_Movimiento == null)
            {
                return HttpNotFound();
            }
            return View(bitacora_Movimiento);
        }

        // POST: Bitacoras_Movimiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bitacora_Movimiento bitacora_Movimiento = db.Bitacora_Movimiento.Find(id);
            db.Bitacora_Movimiento.Remove(bitacora_Movimiento);
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
