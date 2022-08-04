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
    public class ReportePlacasController : Controller
    {
        private DB_A698ED_ericyamiEntities db = new DB_A698ED_ericyamiEntities();

        // GET: ReportePlacas
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

        // GET: ReportePlacas/Details/5
        public ActionResult Details(int? id)
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

        // GET: ReportePlacas/Create
        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Cedula");
            ViewBag.IdMarca = new SelectList(db.Marcas, "IdMarca", "NombreMarca");
            return View();
        }

        // POST: ReportePlacas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPlaca,PlacaN,Color,Modelo,Transmision,Estilo,IdMarca,IdCliente")] Placa placa)
        {
            if (ModelState.IsValid)
            {
                db.Placas.Add(placa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Cedula", placa.IdCliente);
            ViewBag.IdMarca = new SelectList(db.Marcas, "IdMarca", "NombreMarca", placa.IdMarca);
            return View(placa);
        }

        // GET: ReportePlacas/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: ReportePlacas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPlaca,PlacaN,Color,Modelo,Transmision,Estilo,IdMarca,IdCliente")] Placa placa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(placa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Cedula", placa.IdCliente);
            ViewBag.IdMarca = new SelectList(db.Marcas, "IdMarca", "NombreMarca", placa.IdMarca);
            return View(placa);
        }

        // GET: ReportePlacas/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: ReportePlacas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Placa placa = db.Placas.Find(id);
            db.Placas.Remove(placa);
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
