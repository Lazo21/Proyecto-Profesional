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
    public class HistoricosController : Controller
    {
        private DB_A698ED_ericyamiEntities db = new DB_A698ED_ericyamiEntities();

        // GET: Historicos
        public ActionResult Index(String BuscarHisto)
        {
            try
            {
                var historicoes = db.Historicoes.Include(p => p.Cliente).Include(p => p.Placa);
                var busHist = from s in db.Historicoes select s;
                if (!String.IsNullOrEmpty(BuscarHisto))
                {
                    busHist = busHist.Where(j => j.IdHistorico.ToString().Contains(BuscarHisto) || j.Nombre.Contains(BuscarHisto) || j.Placa.PlacaN.Contains(BuscarHisto) || j.Cliente.Cedula.Contains(BuscarHisto));
                    return View(busHist.ToList());
                }
                return View(historicoes.ToList());
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        // GET: Historicos/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historico historico = db.Historicoes.Find(id);
            if (historico == null)
            {
                return HttpNotFound();
            }
            return View(historico);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        // GET: Historicos/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Cedula");
                ViewBag.IdEmpleado = new SelectList(db.Empleadoes, "IdEmpleado", "Cedula");
                ViewBag.IdPlaca = new SelectList(db.Placas, "IdPlaca", "PlacaN");
                ViewBag.IdServicio = new SelectList(db.Servicios, "IdServicio", "NombreServicio");
                return View();
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        // POST: Historicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdHistorico,IdPlaca,IdCliente,Nombre,IdServicio,Detalle,FechaEntrada,FechaReparacion,FechaSalida,IdEmpleado")] Historico historico)
        {
            try
            {
                if (ModelState.IsValid)
            {
                db.Historicoes.Add(historico);
                db.SaveChanges();

                    var plac = (from x in db.Placas
                                where x.IdPlaca == historico.IdPlaca
                                select x.PlacaN).FirstOrDefault();

                    var Bitacoras_Movimiento = new Bitacora_Movimiento
                    {
                        Usuario = User.Identity.Name,
                        FechaHoraMovimiento = DateTime.Now,
                        TipoMovimiento = "Insertar",
                        DetalleMovimiento = "Se Inserto un Historico Placa",
                        IdRef = plac,
                    };
                    db.Bitacora_Movimiento.Add(Bitacoras_Movimiento);
                    db.SaveChanges();

                    return RedirectToAction("Index", new { evento = 1 });
            }

            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Cedula", historico.IdCliente);
            ViewBag.IdEmpleado = new SelectList(db.Empleadoes, "IdEmpleado", "Cedula", historico.IdEmpleado);
            ViewBag.IdPlaca = new SelectList(db.Placas, "IdPlaca", "PlacaN", historico.IdPlaca);
            ViewBag.IdServicio = new SelectList(db.Servicios, "IdServicio", "NombreServicio", historico.IdServicio);
            return View(historico);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        // GET: Historicos/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historico historico = db.Historicoes.Find(id);
            if (historico == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Cedula", historico.IdCliente);
            ViewBag.IdEmpleado = new SelectList(db.Empleadoes, "IdEmpleado", "Cedula", historico.IdEmpleado);
            ViewBag.IdPlaca = new SelectList(db.Placas, "IdPlaca", "PlacaN", historico.IdPlaca);
            ViewBag.IdServicio = new SelectList(db.Servicios, "IdServicio", "NombreServicio", historico.IdServicio);
            return View(historico);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        // POST: Historicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdHistorico,IdPlaca,IdCliente,Nombre,IdServicio,Detalle,FechaEntrada,FechaReparacion,FechaSalida,IdEmpleado")] Historico historico)
        {
            try
            {
                if (ModelState.IsValid)
            {
                db.Entry(historico).State = EntityState.Modified;
                db.SaveChanges();

                    var plac = (from x in db.Placas
                                where x.IdPlaca == historico.IdPlaca
                                select x.PlacaN).FirstOrDefault();

                    var Bitacoras_Movimiento = new Bitacora_Movimiento
                    {
                        Usuario = User.Identity.Name,
                        FechaHoraMovimiento = DateTime.Now,
                        TipoMovimiento = "Modificar",
                        DetalleMovimiento = "Se Modificó un Historico Placa",
                        IdRef = plac,
                    };
                    db.Bitacora_Movimiento.Add(Bitacoras_Movimiento);
                    db.SaveChanges();

                    return RedirectToAction("Index", new { evento = 2 });
            }
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Cedula", historico.IdCliente);
            ViewBag.IdEmpleado = new SelectList(db.Empleadoes, "IdEmpleado", "Cedula", historico.IdEmpleado);
            ViewBag.IdPlaca = new SelectList(db.Placas, "IdPlaca", "PlacaN", historico.IdPlaca);
            ViewBag.IdServicio = new SelectList(db.Servicios, "IdServicio", "NombreServicio", historico.IdServicio);
            return View(historico);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        // GET: Historicos/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historico historico = db.Historicoes.Find(id);
            if (historico == null)
            {
                return HttpNotFound();
            }
            return View(historico);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        // POST: Historicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Historico historico = db.Historicoes.Find(id);
                db.Historicoes.Remove(historico);
                db.SaveChanges();

                var plac = (from x in db.Placas
                            where x.IdPlaca == historico.IdPlaca
                            select x.PlacaN).FirstOrDefault();

                var Bitacoras_Movimiento = new Bitacora_Movimiento
                {
                    Usuario = User.Identity.Name,
                    FechaHoraMovimiento = DateTime.Now,
                    TipoMovimiento = "Eliminar",
                    DetalleMovimiento = "Se Eliminó un Historico Placa",
                    IdRef = plac,
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
