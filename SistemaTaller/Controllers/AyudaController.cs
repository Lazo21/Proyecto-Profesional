using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaTaller.Controllers
{
    public class AyudaController : Controller
    {
        // GET: Ayuda
        public FileResult Index()
        {
            var ruta = Server.MapPath("bach_sist.pdf");
            return File(ruta, "application/pdf", "Manual de Ayuda.pdf");
        }
    }
}