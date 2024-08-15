using System.ComponentModel.DataAnnotations;

namespace one2Do.ViewModels;

public class LoginViewModel
{

    [Required]
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [Display(Name = "Remember Me")]
    public bool RememberMe { get; set; }

}
