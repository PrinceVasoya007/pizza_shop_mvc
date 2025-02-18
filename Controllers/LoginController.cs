using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using pizza_shop_MVC.Models;
using pizza_shop_MVC.Services;
using pizza_shop_MVC.ViewModels;
using System.Net;
using System.Net.Mail;

namespace pizza_shop_MVC.Controllers;

public class LoginController : Controller
{
    // private readonly ILogger<LoginController> _logger;

    // public LoginController(ILogger<LoginController> logger)
    // {
    //     _logger = logger;
    // }

    private readonly PizzaShopContext _db;


    public LoginController(PizzaShopContext db  )

    {

        _db = db;
    }

    

    public IActionResult Index()

    {
     if (HttpContext.Request.Cookies.TryGetValue("user_email", out var userEmail))
       {
                        return RedirectToAction("Index", "Home");

       }

        
        return View();
    }

    // post method
    [HttpPost]
    [ValidateAntiForgeryToken]

    public IActionResult Index(LoginModel account)
    {

        if (ModelState.IsValid)
        {   if(account.Checkbox){
             var cookieOptions = new CookieOptions
            {
                Expires = DateTime.UtcNow.AddDays(3),
                HttpOnly = true,
                Secure = true,
                IsEssential = true
            };
            HttpContext.Response.Cookies.Append("user_email", account.Email, cookieOptions);
        }
            
            // ViewBag.ForgotEmail = account.Email;
          
            var user = _db.Accounts.FirstOrDefault(u => u.Email == account.Email && u.Password == account.Password);
            if (user != null)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("Email", "Email or Password is invalid");
            // return RedirectToAction("Index", "Login");
        }
        return View(account);
    }
 
    public IActionResult Forgotpassword( string email)
    {
           
                 ViewBag.Email = email;
            return View();
        }

    //Post method
    [HttpPost]
    [ValidateAntiForgeryToken]
    public   IActionResult ForgotPassword(ForgotPasswordModel account)
    {
        if (ModelState.IsValid == true)
        {    
            var user = _db.Accounts.FirstOrDefault(u => u.Email == account.Email);
            if (user != null)
            {
                 try
        {
            string toEmail = account.Email; // replace with recipient's email
            string subject = "Test Email";
            string body = "This is a test email.";

            SendEmail(toEmail, subject, body);
            ViewBag.Message = "Email Sent Successfully!";

            return RedirectToAction("Index", "Login");  
        }
        catch (Exception ex)
        {
            ViewBag.Message = "Error sending email: " + ex.Message;
        }

       
                
            }
            ModelState.AddModelError("Email", "Email does not exist");
        }
        return View(account);

    }

// reset password get method
   public IActionResult ResetPassword(){
    

         return View();
   }
   [HttpPost]
    [ValidateAntiForgeryToken]
   public IActionResult ResetPassword(ResetPasswordModel model){

         return View();
   }

//  function to send email
       private void SendEmail(string toEmail, string subject, string body)
    {
        string smtpHost = "mail.etatvasoft.com"; // replace with your SMTP server
        int smtpPort = 587; // or use 465 for SSL
        string smtpUser = "test.dotnet@etatvasoft.com"; // your SMTP username
        string smtpPassword = "P}N^{z-]7Ilp"; // your SMTP password

        var smtpClient = new SmtpClient(smtpHost)
        {
            Port = smtpPort,
            Credentials = new NetworkCredential(smtpUser, smtpPassword),
            EnableSsl = true
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress(smtpUser),
            Subject = subject,
            Body = body,
            IsBodyHtml = false
        };

        mailMessage.To.Add(toEmail);
        
        smtpClient.Send(mailMessage);
    }



}
