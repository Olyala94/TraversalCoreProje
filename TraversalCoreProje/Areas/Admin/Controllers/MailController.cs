
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

using TraversalCoreProje.Models;


namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(MailRequest mailRequest)
        {
            MimeMessage mimeMessage = new MimeMessage();
                                                                    //Gönderenin bilğisi
            MailboxAddress mailboxAddress = new MailboxAddress("Admin", "travelproject05@gmail.com");
            mimeMessage.From.Add(mailboxAddress);
                                                                    //Alıcının Bilğisi
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuider = new BodyBuilder();
            bodyBuider.TextBody = mailRequest.Body;
            mimeMessage.Body= bodyBuider.ToMessageBody();

            mimeMessage.Subject= mailRequest.Subject;   

             SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
                                                              //token
            client.Authenticate("travelproject05@gmail.com", "lqexmdxuidgvzcwr");
            client.Send(mimeMessage);
            client.Disconnect(true);


           // mimeMessage.Body=mailRequest.Body.ToString();

            return View();
        }
    }
}
//travelproject05 @gmail.com