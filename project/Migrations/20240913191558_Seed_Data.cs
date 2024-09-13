using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace project.Migrations
{
    /// <inheritdoc />
    public partial class Seed_Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Drinks, including soft drinks, water, and juice.", "Beverages" },
                    { 2, "Freshly baked bread, pastries, and cakes.", "Bakery" },
                    { 3, "Milk, yogurt, cheese, and other dairy products.", "Dairy" },
                    { 4, "Frozen vegetables, meats, and ready-to-eat meals.", "Frozen Foods" },
                    { 5, "Fresh fruits and vegetables.", "Produce" },
                    { 6, "Fresh meat, poultry, and seafood.", "Meat" },
                    { 7, "Chips, cookies, candies, and other snacks.", "Snacks" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImagePath", "Quantity", "Title", "price" },
                values: new object[,]
                {
                    { 1, 1, "Carbonated soft drink.", "/images/Products/coca-cola.jpg", 100, "Coca-Cola", 1.50m },
                    { 2, 1, "Popular cola drink.", "/images/Products/pepsi.jpg", 120, "Pepsi", 1.50m },
                    { 3, 1, "1 liter of fresh orange juice.", "/images/Products/orange-juice.jpg", 80, "Orange Juice", 3.00m },
                    { 4, 2, "Freshly baked sourdough.", "/images/Products/sourdough.jpg", 50, "Sourdough Bread", 2.50m },
                    { 5, 2, "Buttery flaky croissant.", "/images/Products/croissant.jpg", 60, "Croissant", 1.75m },
                    { 6, 2, "Rich chocolate cake.", "/images/Products/chocolate-cake.jpg", 10, "Chocolate Cake", 15.00m },
                    { 7, 3, "1 liter of whole milk.", "/images/Products/whole-milk.jpg", 90, "Whole Milk", 1.20m },
                    { 8, 3, "200g of cheddar cheese.", "/images/Products/cheddar.jpg", 40, "Cheddar Cheese", 4.50m },
                    { 9, 3, "500g of plain Greek yogurt.", "/images/Products/greek-yogurt.jpg", 30, "Greek Yogurt", 3.00m },
                    { 10, 4, "500g of frozen peas.", "/images/Products/frozen-peas.jpg", 75, "Frozen Peas", 2.00m },
                    { 11, 4, "12-inch frozen pizza.", "/images/Products/frozen-pizza.jpg", 25, "Frozen Pizza", 6.50m },
                    { 12, 4, "1kg of chicken nuggets.", "/images/Products/frozen-nuggets.jpg", 35, "Frozen Chicken Nuggets", 8.00m },
                    { 13, 5, "1kg of bananas.", "/images/Products/bananas.jpg", 100, "Bananas", 0.99m },
                    { 14, 5, "1kg of fresh carrots.", "/images/Products/carrots.jpg", 85, "Carrots", 1.20m },
                    { 15, 5, "1kg of red apples.", "/images/Products/apples.jpg", 70, "Apples", 2.50m },
                    { 16, 6, "1kg of chicken breast.", "/images/Products/chicken-breast.jpg", 45, "Chicken Breast", 5.00m },
                    { 17, 6, "1kg of fresh salmon fillet.", "/images/Products/salmon.jpg", 20, "Salmon Fillet", 12.00m },
                    { 18, 6, "1kg of lean ground beef.", "/images/Products/ground-beef.jpg", 30, "Ground Beef", 7.50m },
                    { 19, 7, "150g bag of potato chips.", "/images/Products/potato-chips.jpg", 100, "Potato Chips", 2.00m },
                    { 20, 7, "200g of chocolate chip cookies.", "/images/Products/chocolate-cookies.jpg", 60, "Chocolate Cookies", 3.50m },
                    { 21, 7, "300g of salted mixed nuts.", "/images/Products/mixed-nuts.jpg", 50, "Mixed Nuts", 5.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7);
        }
    }
}
