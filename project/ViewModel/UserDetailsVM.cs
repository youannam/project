using Microsoft.AspNetCore.Mvc;
using project.Consts;
using System.ComponentModel.DataAnnotations;

namespace project.ViewModel
{
    public class UserDetailsVM
    {
        public int Id { get; set; }

        [MaxLength(100)]
        [MinLength(3, ErrorMessage = "Minimum Length is 3 char")]
        public string FirstName { get; set; }

        [MaxLength(100)]
        [MinLength(3, ErrorMessage = "Minimum Length is 3 char")]
        public string LastName { get; set; }
        public string UserName { get; set; }

        [EmailAddress]
        [Remote("EmailUniqueCheck", "User", AdditionalFields="Id", ErrorMessage = "Email already registered")]
        [RegularExpression(RegexPatterns.EmailPattern, ErrorMessage = Errors.Email)]
        public string Email { get; set; }
    }
}
