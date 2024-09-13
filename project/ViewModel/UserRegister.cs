using Microsoft.AspNetCore.Mvc;
using project.Consts;
using System.ComponentModel.DataAnnotations;

namespace project.ViewModel
{
    public class UserRegister
    {
        [MaxLength(100)]
        [MinLength(3, ErrorMessage = "Minimum Length is 3 char")]
        public string FirstName { get; set; }

        [MaxLength(100)]
        [MinLength(3, ErrorMessage = "Minimum Length is 3 char")]
        public string LastName { get; set; }

        [Remote("UserNameUniqueCheck", "Account", ErrorMessage = "UserName already taken")]
        [RegularExpression(RegexPatterns.EnglishLettersAndNumbersOnlyPattern, ErrorMessage = Errors.EnglishLettersAndNumbers)]
        public string UserName { get; set; }

        [EmailAddress]
        [Remote("EmailUniqueCheck", "Account", ErrorMessage = "Email already registered")]
        [RegularExpression(RegexPatterns.EmailPattern, ErrorMessage = Errors.Email)]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = Errors.PasswordMinValue, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [RegularExpression(RegexPatterns.PasswordPattern, ErrorMessage = Errors.PasswordPattern)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = Errors.PasswordMisMatch)]
        public string ConfirmPassword { get; set; }
    }
}
