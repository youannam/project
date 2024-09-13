using Microsoft.AspNetCore.Mvc;
using project.Consts;
using System.ComponentModel.DataAnnotations;

namespace project.ViewModel
{
    public class CategoryVM
    {
        public int? CategoryId { get; set; }

        [Required, MaxLength(100)]
        [MinLength(2, ErrorMessage = "Minimum Length is 2 char")]
        [Remote("checkUnique", "Category", AdditionalFields = "CategoryId", ErrorMessage = "Category Already Exist!")]
        [RegularExpression(RegexPatterns.EnglishLettersOnlyPattern, ErrorMessage = Errors.EnglishLettersOnly)]
        public string Name { get; set; }

        [Required, MaxLength(500)]
        [MinLength(3, ErrorMessage = "Minimum Length is 3 char")]
        public string Description { get; set; }
    }
}
