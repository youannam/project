using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using project.Models;

namespace project.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(u => u.CategoryId);

            builder.Property(u => u.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.Description)
                .HasMaxLength(500)
                .IsRequired();

            builder.HasIndex(u => u.Name)
            .IsUnique();

            //Seed Data
            builder.HasData(Categories());

        }

        public static List<Category> Categories()
        {
            var _Category = new List<Category>
            {
               new Category { CategoryId = 1, Name = "Beverages", Description = "Drinks, including soft drinks, water, and juice." },
               new Category { CategoryId = 2, Name = "Bakery", Description = "Freshly baked bread, pastries, and cakes." },
               new Category { CategoryId = 3, Name = "Dairy", Description = "Milk, yogurt, cheese, and other dairy products." },
               new Category { CategoryId = 4, Name = "Frozen Foods", Description = "Frozen vegetables, meats, and ready-to-eat meals." },
               new Category { CategoryId = 5, Name = "Produce", Description = "Fresh fruits and vegetables." },
               new Category { CategoryId = 6, Name = "Meat", Description = "Fresh meat, poultry, and seafood." },
               new Category { CategoryId = 7, Name = "Snacks", Description = "Chips, cookies, candies, and other snacks." },
            };

            return _Category;
        }

    }
}
