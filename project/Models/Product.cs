using System.ComponentModel.DataAnnotations.Schema;

namespace project.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual Category? Category { get; set; }

    }
}
