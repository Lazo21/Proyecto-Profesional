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
    public class UsuariosController : Controller
    {
        private DB_A698ED_ericyamiEntities db = new DB_A698ED_ericyamiEntities();

        // GET: Usuarios
        public ActionResult Index(String BuscarUsuario)
        {
            try
            {
                var asuarios = db.Usuarios.Include(u => u.AspNetUser);
                var buscUsu = from s in db.Usuarios select s;
                if (!String.IsNullOrEmpty(BuscarUsuario))
                {
                    buscUsu = buscUsu.Where(j => j.Detalle.Contains(BuscarUsuario) || j.AspNetUser.Email.Contains(BuscarUsuario));
                    return View(buscUsu.ToList());
                }
                return View(asuarios.ToList());
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.RoleId = new SelectList(db.AspNetRoles, "Id", "Name");
                ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "Email");
                return View();
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUsuario,Id,Estado,Detalle,RoleId")] Usuario usuario)
        {
            try
            {
                if (db.Usuarios.Any(a => a.Id == usuario.Id))
                {
                    ModelState.AddModelError("", "Ya existe este correo");
                }

                if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();

                    var usu = usuario.Id;
                    var Bitacoras_Movimiento = new Bitacora_Movimiento
                    {
                        Usuario = User.Identity.Name,
                        FechaHoraMovimiento = DateTime.Now,
                        TipoMovimiento = "Insertar",
                        DetalleMovimiento = "Se Inserto un Usuario Id",
                        IdRef = usu,
                    };
                    db.Bitacora_Movimiento.Add(Bitacoras_Movimiento);
                    db.SaveChanges();

                    return RedirectToAction("Index", new { evento = 1 });
            }

            ViewBag.RoleId = new SelectList(db.AspNetRoles, "Id", "Name", usuario.RoleId);
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "Email", usuario.Id);
            return View(usuario);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleId = new SelectList(db.AspNetRoles, "Id", "Name", usuario.RoleId);
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "Email", usuario.Id);
            return View(usuario);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUsuario,Id,Estado,Detalle,RoleId")] Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();

                    var usu = usuario.Id;
                    var Bitacoras_Movimiento = new Bitacora_Movimiento
                    {
                        Usuario = User.Identity.Name,
                        FechaHoraMovimiento = DateTime.Now,
                        TipoMovimiento = "Modificar",
                        DetalleMovimiento = "Se Modificó un Usuario Id",
                        IdRef = usu,
                    };
                    db.Bitacora_Movimiento.Add(Bitacoras_Movimiento);
                    db.SaveChanges();

                    return RedirectToAction("Index", new { evento = 2 });
            }
            ViewBag.RoleId = new SelectList(db.AspNetRoles, "Id", "Name", usuario.RoleId);
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "Email", usuario.Id);
            return View(usuario);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Usuario usuario = db.Usuarios.Find(id);
                db.Usuarios.Remove(usuario);
                db.SaveChanges();

                var usu = usuario.Id;
                var Bitacoras_Movimiento = new Bitacora_Movimiento
                {
                    Usuario = User.Identity.Name,
                    FechaHoraMovimiento = DateTime.Now,
                    TipoMovimiento = "Eliminar",
                    DetalleMovimiento = "Se Eliminó un Usuario Id",
                    IdRef = usu,
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
