using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sobre()
        {

            return View();
        }

        public ActionResult Contato()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Contato(ContatoViewModel contato)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    enviaSMTP(contato.Nome, contato.Email, contato.Comentario);

                    return RedirectToAction("Index", "Home");

                }
                catch
                {

                }
            }

            return View();
        }


        protected Boolean enviaSMTP(string nome,string email, string conteudo)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");

                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("cmsrioinfnet@gmail.com", "infnet123");

                mail.From = new MailAddress("cmsrioinfnet@gmail.com", "CMSRIO");
                mail.To.Add("cmsrioinfnet@gmail.com");
                mail.Subject = "Contato";
                mail.Body = "Enviado por:" + nome + "\n" + conteudo;

                smtp.Send(mail);

                return true;
                            

            }
            catch
            {
                return false;
            }

        }


    }
}