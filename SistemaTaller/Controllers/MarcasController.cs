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
    public class MarcasController : Controller
    {
        private DB_A698ED_ericyamiEntities db = new DB_A698ED_ericyamiEntities();

        // GET: Marcas
        public ActionResult Index()
        {
            try
            {
                return View(db.Marcas.ToList());
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        // GET: Marcas/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marca marca = db.Marcas.Find(id);
            if (marca == null)
            {
                return HttpNotFound();
            }
            return View(marca);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        // GET: Marcas/Create
        public ActionResult Create()
        {
            try
            {
                Marca num = new Marca();
                var lastmarca = db.Marcas.OrderByDescending(c => c.CodMarca).FirstOrDefault();
                if (lastmarca == null)
                {
                    num.CodMarca = 1;
                }
                else
                {
                    num.CodMarca = lastmarca.CodMarca + 1;
                }
                return View(num);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        // POST: Marcas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMarca,CodMarca,NombreMarca")] Marca marca)
        {
            try
            {
                if (db.Marcas.Any(a => a.CodMarca == marca.CodMarca))
                {
                    ModelState.AddModelError("CodigoMarca", "Ya existe este Código");
                }
                if (db.Marcas.Any(a => a.NombreMarca == marca.NombreMarca))
                {
                    ModelState.AddModelError("NombreMarca", "Ya existe este Nombre");
                }

                if (ModelState.IsValid)
            {
                db.Marcas.Add(marca);
                db.SaveChanges();

                    var marc = marca.CodMarca.ToString();
                    var Bitacoras_Movimiento = new Bitacora_Movimiento
                    {
                        Usuario = User.Identity.Name,
                        FechaHoraMovimiento = DateTime.Now,
                        TipoMovimiento = "Insertar",
                        DetalleMovimiento = "Se Inserto una Marca Código",
                        IdRef = marc,
                    };
                    db.Bitacora_Movimiento.Add(Bitacoras_Movimiento);
                    db.SaveChanges();

                    return RedirectToAction("Index", new { evento = 1 });
            }

            return View(marca);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        // GET: Marcas/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marca marca = db.Marcas.Find(id);
            if (marca == null)
            {
                return HttpNotFound();
            }
            return View(marca);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        // POST: Marcas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMarca,CodMarca,NombreMarca")] Marca marca)
        {
            try
            {
                if (ModelState.IsValid)
            {
                db.Entry(marca).State = EntityState.Modified;
                db.SaveChanges();

                    var marc = marca.CodMarca.ToString();
                    var Bitacoras_Movimiento = new Bitacora_Movimiento
                    {
                        Usuario = User.Identity.Name,
                        FechaHoraMovimiento = DateTime.Now,
                        TipoMovimiento = "Modificar",
                        DetalleMovimiento = "Se Modificó una Marca Código",
                        IdRef = marc,
                    };
                    db.Bitacora_Movimiento.Add(Bitacoras_Movimiento);
                    db.SaveChanges();

                    return RedirectToAction("Index", new { evento = 2 });
            }
            return View(marca);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        // GET: Marcas/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marca marca = db.Marcas.Find(id);
            if (marca == null)
            {
                return HttpNotFound();
            }
            return View(marca);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        // POST: Marcas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Marca marca = db.Marcas.Find(id);
                db.Marcas.Remove(marca);
                db.SaveChanges();

                var marc = marca.CodMarca.ToString();
                var Bitacoras_Movimiento = new Bitacora_Movimiento
                {
                    Usuario = User.Identity.Name,
                    FechaHoraMovimiento = DateTime.Now,
                    TipoMovimiento = "Eliminar",
                    DetalleMovimiento = "Se Eliminó una Marca Código",
                    IdRef = marc,
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
