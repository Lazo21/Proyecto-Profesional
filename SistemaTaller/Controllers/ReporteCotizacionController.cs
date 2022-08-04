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
    public class ReporteCotizacionController : Controller
    {
        private DB_A698ED_ericyamiEntities db = new DB_A698ED_ericyamiEntities();

        // GET: ReporteCotizacion
        public ActionResult Index(String BuscarCotiz)
        {
            try
            {
                var buscacotiz = from s in db.Cotizacions select s;

                if (!String.IsNullOrEmpty(BuscarCotiz))
                {
                    buscacotiz = buscacotiz.Where(j => j.IdCotizacion.ToString().Contains(BuscarCotiz) || j.CodCotizacion.ToString().Contains(BuscarCotiz) || j.NombreClien.ToString().Contains(BuscarCotiz) || j.NPlaca.Contains(BuscarCotiz) || j.Cedula.Contains(BuscarCotiz));
                    return View(buscacotiz.ToList());
                }

                return View(buscacotiz.ToList());
            }

            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        // GET: ReporteCotizacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cotizacion cotizacion = db.Cotizacions.Find(id);
            if (cotizacion == null)
            {
                return HttpNotFound();
            }
            return View(cotizacion);
        }

        // GET: ReporteCotizacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReporteCotizacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCotizacion,CodCotizacion,NPlaca,Cedula,NombreClien,TelefClien,Email,Fecha,NServicio,Detalle,Monto,Descuento,SubTotal,IVA,Total,Vigencia,NEmpleado")] Cotizacion cotizacion)
        {
            if (ModelState.IsValid)
            {
                db.Cotizacions.Add(cotizacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cotizacion);
        }

        // GET: ReporteCotizacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cotizacion cotizacion = db.Cotizacions.Find(id);
            if (cotizacion == null)
            {
                return HttpNotFound();
            }
            return View(cotizacion);
        }

        // POST: ReporteCotizacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCotizacion,CodCotizacion,NPlaca,Cedula,NombreClien,TelefClien,Email,Fecha,NServicio,Detalle,Monto,Descuento,SubTotal,IVA,Total,Vigencia,NEmpleado")] Cotizacion cotizacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cotizacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cotizacion);
        }

        // GET: ReporteCotizacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cotizacion cotizacion = db.Cotizacions.Find(id);
            if (cotizacion == null)
            {
                return HttpNotFound();
            }
            return View(cotizacion);
        }

        // POST: ReporteCotizacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cotizacion cotizacion = db.Cotizacions.Find(id);
            db.Cotizacions.Remove(cotizacion);
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
