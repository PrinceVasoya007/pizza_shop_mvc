using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using pizza_shop_MVC.Models;
using pizza_shop_MVC.Services;
using pizza_shop_MVC.ViewModels;

namespace pizza_shop_MVC.Controllers;

public class LoginController : Controller
{
    // private readonly ILogger<LoginController> _logger;

    // public LoginController(ILogger<LoginController> logger)
    // {
    //     _logger = logger;
    // }

    private readonly PizzaShopContext _db;
     private readonly EmailService _emailService;


    public LoginController(PizzaShopContext db , EmailService emailService)

    {

        _db = db;
        _emailService = emailService;   
    }

    

    public IActionResult Index()
    {
        return View();
    }

    // post method
    [HttpPost]
    [ValidateAntiForgeryToken]

    public IActionResult Index(LoginModel account)
    {

        if (ModelState.IsValid)
        {  
            //  resetEmail = account.Email;
            ViewBag.resetEmail = account.Email;
            var user = _db.Accounts.FirstOrDefault(u => u.Email == account.Email && u.Password == account.Password);
            if (user != null)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("Email", "Email or Password is invalid");
            // return RedirectToAction("Index", "Login");
        }
        return View();
    }
 
    public IActionResult ResetPassword( string email)
    {
           

            // var model = new ResetPasswordModel { Email = email };
                 ViewBag.Email ="Prince@gmail.com";
            return View();
        }

    //Post method
    [HttpPost]
    [ValidateAntiForgeryToken]
    public   Task<IActionResult>  ResetPassword(ResetPasswordModel account)
    {
        if (ModelState.IsValid == true)
        {    
            var user = _db.Accounts.FirstOrDefault(u => u.Email == account.Email);
            if (user != null)
            {
                _emailService.SendEmailAsync(account.Email, "Your password reset link");
                return Task.FromResult<IActionResult>(RedirectToAction("Index", "Login"));
            }
            ModelState.AddModelError("Email", "Email does not exist");
        }
        return Task.FromResult<IActionResult>(View(account));

    }



}
