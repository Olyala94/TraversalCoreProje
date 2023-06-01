using DocumentFormat.OpenXml.Office2021.DocumentTasks;
using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Threading.Tasks;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Controllers
{  
    [AllowAnonymous]
    public class PasswordChangeController : Controller
    {
     
        private readonly UserManager<AppUser> _userManager;

        public PasswordChangeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel forgetPasswordViewModel)
        {
            var user = await _userManager.FindByEmailAsync(forgetPasswordViewModel.Mail);
            string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var passswordResetTokenLink = Url.Action("ResetPassword", "PasswordChange", new
            {
                userId = user.Id,
                token=passwordResetToken
            },HttpContext.Request.Scheme);

            MimeMessage mimeMessage = new MimeMessage();
                                                               //Gönderenin bilğisi....
            MailboxAddress mailboxAddress = new MailboxAddress("Admin", "travelproject05@gmail.com");
            mimeMessage.From.Add(mailboxAddress);
                                                                //Alıcıcın Bilğisi....
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", forgetPasswordViewModel.Mail);
            mimeMessage.To.Add(mailboxAddressTo);


            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = $"<a href=\"{passswordResetTokenLink}\">{passswordResetTokenLink}</a>";
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            //var bodyBuider = new BodyBuilder();
            //bodyBuider.TextBody = passswordResetTokenLink;
            //mimeMessage.Body = bodyBuider.ToMessageBody();

            mimeMessage.Subject = "Şifre Değişiklik Talebi";

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("travelproject05@gmail.com", "grzwgvvidjhwmaew"); //token --> "grzwgvvidjhwmaew"
            client.Send(mimeMessage);
            client.Disconnect(true);

            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string userid, string token) 
        {
            TempData["userid"] = userid;
            TempData["token"] = token;  
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            var userid = TempData["userid"];
            var token = TempData["token"];  
            if(userid ==null || token ==null)
            {
                //hata mesajı oluşur
            }
            var user = await _userManager.FindByIdAsync(userid.ToString());
            //Eğer Başarılıysa kişiyi sayfaya yönlendir
          var result =  await _userManager.ResetPasswordAsync(user, token.ToString(), resetPasswordViewModel.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Login");
            }

            return View();
        }
    }
}
