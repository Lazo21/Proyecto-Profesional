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
    public class CotizacionesController : Controller
    {
        private DB_A698ED_ericyamiEntities db = new DB_A698ED_ericyamiEntities();

        // GET: Cotizaciones
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
        // GET: Cotizaciones/Details/5
        public ActionResult Details(int? id)
        {
            try
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
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        // GET: Cotizaciones/Create
        public ActionResult Create()
        {
            try
            {
                Cotizacion num = new Cotizacion();
                var lastcotiz = db.Cotizacions.OrderByDescending(c => c.CodCotizacion).FirstOrDefault();
                if (lastcotiz == null)
                {
                    num.CodCotizacion = 1;
                }
                else
                {
                    num.CodCotizacion = lastcotiz.CodCotizacion + 1;
                }

                return View(num);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        // POST: Cotizaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCotizacion,CodCotizacion,NPlaca,Cedula,NombreClien,TelefClien,Email,Fecha,NServicio,Detalle,Monto,Descuento,SubTotal,IVA,Total,Vigencia,NEmpleado")] Cotizacion cotizacion)
        {
            try
            {
                if (ModelState.IsValid)
            {
                db.Cotizacions.Add(cotizacion);
                db.SaveChanges();

                    var cotiz = cotizacion.CodCotizacion.ToString();
                    var Bitacoras_Movimiento = new Bitacora_Movimiento
                    {
                        Usuario = User.Identity.Name,
                        FechaHoraMovimiento = DateTime.Now,
                        TipoMovimiento = "Insertar",
                        DetalleMovimiento = "Se Inserto una Cotización Código",
                        IdRef = cotiz,
                    };
                    db.Bitacora_Movimiento.Add(Bitacoras_Movimiento);
                    db.SaveChanges();

                    return RedirectToAction("Index", new { evento = 1 });
            }

            return View(cotizacion);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        // GET: Cotizaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            try
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
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        // POST: Cotizaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCotizacion,CodCotizacion,NPlaca,Cedula,NombreClien,TelefClien,Email,Fecha,NServicio,Detalle,Monto,Descuento,SubTotal,IVA,Total,Vigencia,NEmpleado")] Cotizacion cotizacion)
        {
            try
            {
                if (ModelState.IsValid)
            {
                db.Entry(cotizacion).State = EntityState.Modified;
                db.SaveChanges();

                    var cotiz = cotizacion.CodCotizacion.ToString();
                    var Bitacoras_Movimiento = new Bitacora_Movimiento
                    {
                        Usuario = User.Identity.Name,
                        FechaHoraMovimiento = DateTime.Now,
                        TipoMovimiento = "Modificar",
                        DetalleMovimiento = "Se Modificó una Cotización Código",
                        IdRef = cotiz,
                    };
                    db.Bitacora_Movimiento.Add(Bitacoras_Movimiento);
                    db.SaveChanges();

                    return RedirectToAction("Index", new { evento = 2 });
            }
            return View(cotizacion);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        // GET: Cotizaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            try
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
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        // POST: Cotizaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Cotizacion cotizacion = db.Cotizacions.Find(id);
                db.Cotizacions.Remove(cotizacion);
                db.SaveChanges();

                var cotiz = cotizacion.CodCotizacion.ToString();
                var Bitacoras_Movimiento = new Bitacora_Movimiento
                {
                    Usuario = User.Identity.Name,
                    FechaHoraMovimiento = DateTime.Now,
                    TipoMovimiento = "Eliminar",
                    DetalleMovimiento = "Se Eliminó una Cotización Código",
                    IdRef = cotiz,
                };
                db.Bitacora_Movimiento.Add(Bitacoras_Movimiento);
                db.SaveChanges();

                return RedirectToAction("Index", new { evento = 3 });
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
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
