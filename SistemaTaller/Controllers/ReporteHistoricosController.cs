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
    public class ReporteHistoricosController : Controller
    {
        private DB_A698ED_ericyamiEntities db = new DB_A698ED_ericyamiEntities();

        // GET: ReporteHistoricos
        public ActionResult Index(String BuscarHisto)
        {
            try
            {
                var historicoes = db.Historicoes.Include(p => p.Cliente).Include(p => p.Placa);
                var busHist = from s in db.Historicoes select s;
                if (!String.IsNullOrEmpty(BuscarHisto))
                {
                    busHist = busHist.Where(j => j.IdHistorico.ToString().Contains(BuscarHisto) || j.Nombre.Contains(BuscarHisto) || j.Placa.PlacaN.Contains(BuscarHisto));
                    return View(busHist.ToList());
                }
                return View(historicoes.ToList());
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        // GET: ReporteHistoricos/Details/5
        public ActionResult Details(int? id)
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

        // GET: ReporteHistoricos/Create
        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Cedula");
            ViewBag.IdEmpleado = new SelectList(db.Empleadoes, "IdEmpleado", "Cedula");
            ViewBag.IdPlaca = new SelectList(db.Placas, "IdPlaca", "PlacaN");
            ViewBag.IdServicio = new SelectList(db.Servicios, "IdServicio", "NombreServicio");
            return View();
        }

        // POST: ReporteHistoricos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdHistorico,IdPlaca,IdCliente,Nombre,IdServicio,Detalle,FechaEntrada,FechaReparacion,FechaSalida,IdEmpleado")] Historico historico)
        {
            if (ModelState.IsValid)
            {
                db.Historicoes.Add(historico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Cedula", historico.IdCliente);
            ViewBag.IdEmpleado = new SelectList(db.Empleadoes, "IdEmpleado", "Cedula", historico.IdEmpleado);
            ViewBag.IdPlaca = new SelectList(db.Placas, "IdPlaca", "PlacaN", historico.IdPlaca);
            ViewBag.IdServicio = new SelectList(db.Servicios, "IdServicio", "NombreServicio", historico.IdServicio);
            return View(historico);
        }

        // GET: ReporteHistoricos/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: ReporteHistoricos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdHistorico,IdPlaca,IdCliente,Nombre,IdServicio,Detalle,FechaEntrada,FechaReparacion,FechaSalida,IdEmpleado")] Historico historico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Cedula", historico.IdCliente);
            ViewBag.IdEmpleado = new SelectList(db.Empleadoes, "IdEmpleado", "Cedula", historico.IdEmpleado);
            ViewBag.IdPlaca = new SelectList(db.Placas, "IdPlaca", "PlacaN", historico.IdPlaca);
            ViewBag.IdServicio = new SelectList(db.Servicios, "IdServicio", "NombreServicio", historico.IdServicio);
            return View(historico);
        }

        // GET: ReporteHistoricos/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: ReporteHistoricos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Historico historico = db.Historicoes.Find(id);
            db.Historicoes.Remove(historico);
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
