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
    public class EmpleadosController : Controller
    {
        private DB_A698ED_ericyamiEntities db = new DB_A698ED_ericyamiEntities();

        // GET: Empleados
        public ActionResult Index(String BuscarEmpleado)
        {
            try
            {

                var buscEmpl = from s in db.Empleadoes select s;
                if (!String.IsNullOrEmpty(BuscarEmpleado))
                {
                    buscEmpl = buscEmpl.Where(j => j.Cedula.Contains(BuscarEmpleado) || j.Nombre.Contains(BuscarEmpleado) || j.Email.Contains(BuscarEmpleado));
                    return View(buscEmpl.ToList());
                }
                return View(db.Empleadoes.ToList());
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        // GET: Empleados/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleadoes.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEmpleado,Cedula,Nombre,Telefono,Direccion,Email")] Empleado empleado)
        {
            try
            {
                if (db.Empleadoes.Any(a => a.Cedula == empleado.Cedula))
                {
                    ModelState.AddModelError("Cedula", "Ya existe esta Cédula");
                }
                if (db.Empleadoes.Any(a => a.Email == empleado.Email))
                {
                    ModelState.AddModelError("", "Ya existe este correo");
                }

                if (ModelState.IsValid)
            {
                db.Empleadoes.Add(empleado);
                db.SaveChanges();

                    var ced = empleado.Cedula;
                    var Bitacoras_Movimiento = new Bitacora_Movimiento
                    {
                        Usuario = User.Identity.Name,
                        FechaHoraMovimiento = DateTime.Now,
                        TipoMovimiento = "Insertar",
                        DetalleMovimiento = "Se Inserto un Empleado Cédula",
                        IdRef = ced,
                    };
                    db.Bitacora_Movimiento.Add(Bitacoras_Movimiento);
                    db.SaveChanges();

                    return RedirectToAction("Index", new { evento = 1 });
            }

            return View(empleado);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleadoes.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEmpleado,Cedula,Nombre,Telefono,Direccion,Email")] Empleado empleado)
        {
            try
            {
                if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();

                    var ced = empleado.Cedula;
                    var Bitacoras_Movimiento = new Bitacora_Movimiento
                    {
                        Usuario = User.Identity.Name,
                        FechaHoraMovimiento = DateTime.Now,
                        TipoMovimiento = "Modificar",
                        DetalleMovimiento = "Se Modificó un Empleado Cédula",
                        IdRef = ced,
                    };
                    db.Bitacora_Movimiento.Add(Bitacoras_Movimiento);
                    db.SaveChanges();

                    return RedirectToAction("Index", new { evento = 2 });
            }
            return View(empleado);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleadoes.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Empleado empleado = db.Empleadoes.Find(id);
                db.Empleadoes.Remove(empleado);
                db.SaveChanges();

                var ced = empleado.Cedula;
                var Bitacoras_Movimiento = new Bitacora_Movimiento
                {
                    Usuario = User.Identity.Name,
                    FechaHoraMovimiento = DateTime.Now,
                    TipoMovimiento = "Eliminar",
                    DetalleMovimiento = "Se Eliminó un Empleado Cédula",
                    IdRef = ced,
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
