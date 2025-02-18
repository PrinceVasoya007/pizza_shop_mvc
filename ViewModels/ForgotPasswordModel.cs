using System.ComponentModel.DataAnnotations;

namespace pizza_shop_MVC.ViewModels;

public class ForgotPasswordModel
{
     [Required(ErrorMessage = "Please Provide Email")]
    [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please Provide Valid Email")]
    public string Email { get; set; } = null!;
}

