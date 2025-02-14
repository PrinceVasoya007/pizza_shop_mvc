using System.ComponentModel.DataAnnotations;

namespace pizza_shop_MVC.ViewModels;

public class LoginModel
{
       [Required(ErrorMessage = "Please Provide Email")]
    [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please Provide Valid Email")]
    public string Email { get; set; } = null!;

       [Required(ErrorMessage = "PLease Enter Your Password")]
               [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$", ErrorMessage = "Password must be at least 6 characters long and contain at least one number, one lowercase letter, one uppercase letter, and one special character.")]  
       
    public string Password { get; set; } = null!;

}
