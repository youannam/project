using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using project.Models;

namespace project.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Configure Id as the primary key
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(200);

            // Configure Price as required and with decimal precision
            builder.Property(p => p.price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Description)
                .HasMaxLength(1000);

            builder.Property(p => p.Quantity)
                .IsRequired();

            builder.Property(p => p.ImagePath)
                .HasMaxLength(500);

            //Seed Products
            builder.HasData(Products());

        }

        public static List<Product> Products()
        {
            var _Product = new List<Product>()
{
// Beverages
new Product { Id = 1, Title = "Coca-Cola", price = 1.50m, Description = "Carbonated soft drink.", Quantity = 100, ImagePath = "/images/Products/coca-cola.jpg", CategoryId = 1 },
new Product { Id = 2, Title = "Pepsi", price = 1.50m, Description = "Popular cola drink.", Quantity = 120, ImagePath = "/images/Products/pepsi.jpg", CategoryId = 1 },
new Product { Id = 3, Title = "Orange Juice", price = 3.00m, Description = "1 liter of fresh orange juice.", Quantity = 80, ImagePath = "/images/Products/orange-juice.jpg", CategoryId = 1 },

// Bakery
new Product { Id = 4, Title = "Sourdough Bread", price = 2.50m, Description = "Freshly baked sourdough.", Quantity = 50, ImagePath = "/images/Products/sourdough.jpg", CategoryId = 2 },
new Product { Id = 5, Title = "Croissant", price = 1.75m, Description = "Buttery flaky croissant.", Quantity = 60, ImagePath = "/images/Products/croissant.jpg", CategoryId = 2 },
new Product { Id = 6, Title = "Chocolate Cake", price = 15.00m, Description = "Rich chocolate cake.", Quantity = 10, ImagePath = "/images/Products/chocolate-cake.jpg", CategoryId = 2 },

// Dairy
new Product { Id = 7, Title = "Whole Milk", price = 1.20m, Description = "1 liter of whole milk.", Quantity = 90, ImagePath = "/images/Products/whole-milk.jpg", CategoryId = 3 },
new Product { Id = 8, Title = "Cheddar Cheese", price = 4.50m, Description = "200g of cheddar cheese.", Quantity = 40, ImagePath = "/images/Products/cheddar.jpg", CategoryId = 3 },
new Product { Id = 9, Title = "Greek Yogurt", price = 3.00m, Description = "500g of plain Greek yogurt.", Quantity = 30, ImagePath = "/images/Products/greek-yogurt.jpg", CategoryId = 3 },

// Frozen Foods
new Product { Id = 10, Title = "Frozen Peas", price = 2.00m, Description = "500g of frozen peas.", Quantity = 75, ImagePath = "/images/Products/frozen-peas.jpg", CategoryId = 4 },
new Product { Id = 11, Title = "Frozen Pizza", price = 6.50m, Description = "12-inch frozen pizza.", Quantity = 25, ImagePath = "/images/Products/frozen-pizza.jpg", CategoryId = 4 },
new Product { Id = 12, Title = "Frozen Chicken Nuggets", price = 8.00m, Description = "1kg of chicken nuggets.", Quantity = 35, ImagePath = "/images/Products/frozen-nuggets.jpg", CategoryId = 4 },

// Produce
new Product { Id = 13, Title = "Bananas", price = 0.99m, Description = "1kg of bananas.", Quantity = 100, ImagePath = "/images/Products/bananas.jpg", CategoryId = 5 },
new Product { Id = 14, Title = "Carrots", price = 1.20m, Description = "1kg of fresh carrots.", Quantity = 85, ImagePath = "/images/Products/carrots.jpg", CategoryId = 5 },
new Product { Id = 15, Title = "Apples", price = 2.50m, Description = "1kg of red apples.", Quantity = 70, ImagePath = "/images/Products/apples.jpg", CategoryId = 5 },

// Meat
new Product { Id = 16, Title = "Chicken Breast", price = 5.00m, Description = "1kg of chicken breast.", Quantity = 45, ImagePath = "/images/Products/chicken-breast.jpg", CategoryId = 6 },
new Product { Id = 17, Title = "Salmon Fillet", price = 12.00m, Description = "1kg of fresh salmon fillet.", Quantity = 20, ImagePath = "/images/Products/salmon.jpg", CategoryId = 6 },
new Product { Id = 18, Title = "Ground Beef", price = 7.50m, Description = "1kg of lean ground beef.", Quantity = 30, ImagePath = "/images/Products/ground-beef.jpg", CategoryId = 6 },

// Snacks
new Product { Id = 19, Title = "Potato Chips", price = 2.00m, Description = "150g bag of potato chips.", Quantity = 100, ImagePath = "/images/Products/potato-chips.jpg", CategoryId = 7 },
new Product { Id = 20, Title = "Chocolate Cookies", price = 3.50m, Description = "200g of chocolate chip cookies.", Quantity = 60, ImagePath = "/images/Products/chocolate-cookies.jpg", CategoryId = 7 },
new Product { Id = 21, Title = "Mixed Nuts", price = 5.00m, Description = "300g of salted mixed nuts.", Quantity = 50, ImagePath = "/images/Products/mixed-nuts.jpg", CategoryId = 7 },

};
            return _Product;
        }
    }
}
