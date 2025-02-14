using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using pizza_shop_MVC.Models;
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

    public LoginController(PizzaShopContext db)
    {

        _db = db;
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
            // ModelState.AddModelError("Email", "Email or Password is invalid");
            return RedirectToAction("Index", "Login");
        }
        return View();
    }

    public IActionResult ResetPassword()
    {  
        
        return View( );
    }

    //Post method
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ResetPassword(Account account)
    {
        if (ModelState.IsValid == true)
        {    
            var user = _db.Accounts.FirstOrDefault(u => u.Email == account.Email);
            if (user != null)
            {
                return RedirectToAction("Index", "Login");
            }
            ModelState.AddModelError("Email", "Email does not exist");
        }
        return View();

    }



}
