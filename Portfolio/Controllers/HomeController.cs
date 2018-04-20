
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using Portfolio.Models.Forms;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendMessage(EmailFormModel model)
        {

            var fromAddress = new MailAddress("automailingportfolio@gmail.com", "Daniel Ferreira");
            var toAddress = new MailAddress("daniel.sa.ferreira.7@gmail.com", "Daniel Ferreira");
            const string fromPassword = "portfolio05";
            const string subject = "Portfolio contact";
            string body = "Nome: " + model.Name + " || Email: " + model.Email + " || Message: " + model.Message;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }

            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}