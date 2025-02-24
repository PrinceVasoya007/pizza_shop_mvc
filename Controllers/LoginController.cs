using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using pizza_shop_MVC.Models;
using pizza_shop_MVC.Services;
using pizza_shop_MVC.ViewModels;
using System.Net;
using System.Net.Mail;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.DataProtection;
using pizza_shop_MVC.Attributes;

namespace pizza_shop_MVC.Controllers;

public class LoginController : Controller
{
    // private readonly ILogger<LoginController> _logger;

    // public LoginController(ILogger<LoginController> logger)
    // {
    //     _logger = logger;
    // }

    private readonly PizzaShopContext _db;
    private readonly IJwtService _jwtService;



    public LoginController(PizzaShopContext db, IJwtService jwtService)

    {

        _db = db;
        _jwtService = jwtService;
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
        {
            if (account.Checkbox)
            {
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
            string role = user?.RoleId.ToString() ?? string.Empty;

            if (user != null)
            {
                var token = _jwtService.GenerateJwtToken(user.Email, user.Password, role);
                var cookieOptions = new CookieOptions
                {

                    Expires = DateTime.UtcNow.AddDays(3),
                    HttpOnly = true,
                    Secure = true,
                    IsEssential = true

                };
                if (HttpContext.Request.Cookies.TryGetValue("Authorize", out var userEmail))
                {
                    return RedirectToAction("Edit");


                }
                else
                {
                    HttpContext.Response.Cookies.Append("Authorize", (string)token, cookieOptions);
                    return RedirectToAction("Edit");

                }
            }
            ModelState.AddModelError("Email", "Email or Password is invalid");
            // return RedirectToAction("Index", "Login");
        }
        return View(account);
    }

    public IActionResult Forgotpassword(string email)
    {

        // ViewBag.Email = email;
        return View();
    }

    //Post method
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ForgotPassword(ForgotPasswordModel account)
    {
        if (ModelState.IsValid == true)
        {
            var user = _db.Accounts.FirstOrDefault(u => u.Email == account.Email);
            if (user != null)
            {
                try
                {
                    string resetToken = _jwtService.GenerateJwtToken(user.Email, user.Password, "admin");
                    // create reset password link
                    string resetLink = Url.Action("ResetPassword", "Login", new { token = resetToken }, Request.Scheme);


                    // Get the base64-encoded image
                    // string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/logos/pizzashop_logo.png");
                    string base64Image = GetBase64Image("wwwroot/images/logos/pizzashop_logo.png");
                    string toEmail = account.Email; // replace with recipient's email
                    string subject = "Reset Password";
                    string body = $@"
            <!DOCTYPE html>
            <html lang='en'>
            <head>
                <meta charset='UTF-8'>
                <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                <title>Forgot Password</title>
            </head>
            <body style='font-family: Arial, sans-serif; margin: 0; padding: 0; background-color: #f4f4f4;'>
                <div style='width: 80%; margin: 20px auto; background: #fff; border-radius: 5px; box-shadow: 0 2px 10px rgba(0,0,0,0.1); overflow: hidden;'>
                    <div style='background-color: #007bff; color: white; padding: 10px 20px; text-align: center;'>
                    <img class='pizaashop_img' src='{base64Image}' style='width: 50px; height: 50px;'>
                        <h2 style='margin: 0; padding: 10px 0;'>PIZZASHOP</h2>
                    </div>
                    <div style='padding: 20px;'>
                        <p style='margin: 0 0 10px;'>Hello,</p>
                        <p style='margin: 0 0 10px;'>Please <a href={resetLink} style='color: #007bff; text-decoration: none;'>click here</a> to reset your account password.</p>
                        <p style='margin: 0 0 10px;'>If you encounter any issues, please contact our support team.</p>
                        <p style='font-weight: bold; color: #ff4d4d; margin: 0 0 10px;'>Important Note: The link will expire in 24 hours.</p>
                    </div>
                </div>
            </body>
            </html>";

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
    public IActionResult ResetPassword()
    {
        var token = Request.Query["token"];


        if (string.IsNullOrEmpty(token))
        {
            return RedirectToAction("Index", "Login");
        }

        ResetPasswordModel model = new ResetPasswordModel()
        {
            Token = token
        };

        return View(model);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ResetPassword(ResetPasswordModel model)
    {
        if (ModelState.IsValid == false)
        {
            var token = model.Token;
            // Decode and validate the token
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var jwtToken = tokenHandler.ReadJwtToken(token) as JwtSecurityToken;

                // var email = jwtToken.Claims.First(claim => claim.Type == ClaimTypes.Email).Value;
                var email = jwtToken?.Claims.FirstOrDefault(claim => claim.Type == "email")?.Value ?? string.Empty;
                var password = jwtToken?.Claims.FirstOrDefault(claim => claim.Type == "Password")?.Value ?? string.Empty;
                // Validate the token (you can add additional validation logic here)
                // For example, check if the token is expired
                if (jwtToken.ValidTo < DateTime.UtcNow)
                {
                    ViewBag.Message = "Token has expired.";
                    return View("Error");
                }


                // Find the user by email and update the password
                var user = _db.Accounts.FirstOrDefault(u => u.Email == email);
                if (user == null)
                {
                    ViewBag.Message = "User not found.";
                    return View("Error");


                }
                else if (user.Password != password)
                {
                    ModelState.AddModelError("password", "Email does not exist");
                    return View(model);
                }
                else
                {
                    user.Password = model.Password; // You should hash the password before storing it
                    _db.SaveChanges();

                    ViewBag.Message = "Password has been reset successfully.";
                    return RedirectToAction("Index", "Login");

                }


            }
            catch (Exception ex)
            {
                ViewBag.Message = "Invalid token: " + ex.Message;
                return View("Error");
            }
        }

        return View(model);
    }

    [CustomAuthorize("1")]
    public IActionResult Edit()
    {

        return View();
    }

    public IActionResult AccessDenied()
    {
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
            IsBodyHtml = true
        };

        mailMessage.To.Add(toEmail);

        smtpClient.Send(mailMessage);
    }
    private string GetBase64Image(string imagePath)
    {
        byte[] imageBytes = System.IO.File.ReadAllBytes(imagePath);
        string base64String = Convert.ToBase64String(imageBytes);
        return $"data:image/png;base64,{base64String}";
    }



}
