using System.ComponentModel.DataAnnotations;

namespace pizza_shop_MVC.ViewModels;

public class ResetPasswordModel
{    
        [Required(ErrorMessage = "Please provide your email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Please Provide Password")]
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$", ErrorMessage = "Password must be at least 6 characters long and contain at least one number, one lowercase letter, one uppercase letter, and one special character.")]  
       

    public string Password { get; set; } = null!;

    [Required(ErrorMessage = "Please Provide Password")]
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$", ErrorMessage = "Password must be at least 6 characters long and contain at least one number, one lowercase letter, one uppercase letter, and one special character.")]  
    [Compare("Password", ErrorMessage = "Password and Confirm Password do not match")]
    public string ConfirmPassword { get; set; } = null!;
}
    