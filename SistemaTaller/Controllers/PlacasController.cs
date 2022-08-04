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
    public class PlacasController : Controller
    {
        private DB_A698ED_ericyamiEntities db = new DB_A698ED_ericyamiEntities();

        // GET: Placas
        public ActionResult Index(String BuscarPlaca)
        {
            try
            {
                var placas = db.Placas.Include(p => p.Cliente).Include(p => p.Marca);
                var busPla = from s in db.Placas select s;
                if (!String.IsNullOrEmpty(BuscarPlaca))
                {
                    busPla = busPla.Where(j => j.IdPlaca.ToString().Contains(BuscarPlaca) || j.Cliente.Cedula.Contains(BuscarPlaca) || j.PlacaN.Contains(BuscarPlaca));
                    return View(busPla.ToList());
                }
                return View(placas.ToList());
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        // GET: Placas/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Placa placa = db.Placas.Find(id);
            if (placa == null)
            {
                return HttpNotFound();
            }
            return View(placa);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        // GET: Placas/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Cedula");
                ViewBag.IdMarca = new SelectList(db.Marcas, "IdMarca", "NombreMarca");
                return View();
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        // POST: Placas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPlaca,PlacaN,Color,Modelo,Transmision,Estilo,IdMarca,IdCliente")] Placa placa)
        {
            try
            {
                if (db.Placas.Any(a => a.PlacaN == placa.PlacaN))
                {
                    ModelState.AddModelError("Placa", "Ya existe esta Placa");
                }
                if (db.Placas.Any(a => a.IdPlaca == placa.IdPlaca))
                {
                    ModelState.AddModelError("", "Ya existe este Numero");
                }
                if (ModelState.IsValid)
            {
                db.Placas.Add(placa);
                db.SaveChanges();

                    var placn = placa.PlacaN;
                    var Bitacoras_Movimiento = new Bitacora_Movimiento
                    {
                        Usuario = User.Identity.Name,
                        FechaHoraMovimiento = DateTime.Now,
                        TipoMovimiento = "Insertar",
                        DetalleMovimiento = "Se Inserto la Placa Número",
                        IdRef = placn,
                    };
                    db.Bitacora_Movimiento.Add(Bitacoras_Movimiento);
                    db.SaveChanges();

                    return RedirectToAction("Index", new { evento = 1 });
            }

            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Cedula", placa.IdCliente);
            ViewBag.IdMarca = new SelectList(db.Marcas, "IdMarca", "NombreMarca", placa.IdMarca);
            return View(placa);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        // GET: Placas/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Placa placa = db.Placas.Find(id);
            if (placa == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Cedula", placa.IdCliente);
            ViewBag.IdMarca = new SelectList(db.Marcas, "IdMarca", "NombreMarca", placa.IdMarca);
            return View(placa);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        // POST: Placas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPlaca,PlacaN,Color,Modelo,Transmision,Estilo,IdMarca,IdCliente")] Placa placa)
        {
            try
            {
                if (ModelState.IsValid)
            {
                db.Entry(placa).State = EntityState.Modified;
                db.SaveChanges();

                    var placn = placa.PlacaN;
                    var Bitacoras_Movimiento = new Bitacora_Movimiento
                    {
                        Usuario = User.Identity.Name,
                        FechaHoraMovimiento = DateTime.Now,
                        TipoMovimiento = "Modificar",
                        DetalleMovimiento = "Se Modificó la Placa Número",
                        IdRef = placn,
                    };
                    db.Bitacora_Movimiento.Add(Bitacoras_Movimiento);
                    db.SaveChanges();

                    return RedirectToAction("Index", new { evento = 2 });
            }
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Cedula", placa.IdCliente);
            ViewBag.IdMarca = new SelectList(db.Marcas, "IdMarca", "NombreMarca", placa.IdMarca);
            return View(placa);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        // GET: Placas/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Placa placa = db.Placas.Find(id);
            if (placa == null)
            {
                return HttpNotFound();
            }
            return View(placa);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        // POST: Placas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Placa placa = db.Placas.Find(id);
                db.Placas.Remove(placa);
                db.SaveChanges();

                var placn = placa.PlacaN;
                var Bitacoras_Movimiento = new Bitacora_Movimiento
                {
                    Usuario = User.Identity.Name,
                    FechaHoraMovimiento = DateTime.Now,
                    TipoMovimiento = "Eliminar",
                    DetalleMovimiento = "Se Eliminó la Placa Número",
                    IdRef = placn,
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
