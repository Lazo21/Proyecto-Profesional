using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;


namespace SistemaTaller.Controllers
{
    public class EnviarCorreoController : Controller
    {
        // GET: EnviarCorreo
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EnviarCorreo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EnviarCorreo(String para, String asunto, String mensaje, HttpPostedFileBase fichero)
        {
            try
            {
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress("erickcest@gmail.com");// El correo que usara mvc para enviar
                correo.To.Add(para);
                correo.Subject = asunto;
                correo.Body = mensaje;
                correo.IsBodyHtml = true;
                correo.Priority = MailPriority.High;

                String ruta = Server.MapPath("../Temporal");
                fichero.SaveAs(ruta + "\\" + fichero.FileName);

                Attachment adjunto = new Attachment(ruta + "\\" + fichero.FileName);
                correo.Attachments.Add(adjunto);
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;
                client.UseDefaultCredentials = true;
                string sCuenta = "erickcest@gmail.com";
                string sPassword = "pig861772";
                client.Credentials = new NetworkCredential(sCuenta, sPassword);
                client.Send(correo);
                ViewBag.Mensaje = "Enviado exitosamente";

            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
            }
            return View();
        }
    }
}