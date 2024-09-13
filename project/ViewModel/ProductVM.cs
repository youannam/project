using project.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project.ViewModel
{
    public class ProductVM
    {
        public int? Id { get; set; }

        public string Title { get; set; }

        [Range(0.00, 999999999999999.99, ErrorMessage = "Price must be between 0.00 and 999,999,999,999,999.99.")]
        public decimal price { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public IFormFile? ImageUrl { get; set; }

        public string? ImagePath { get; set; }

        public int CategoryId { get; set; }

        public string? Category { get; set; }
    }
}
