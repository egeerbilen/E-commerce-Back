using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Drawing.Imaging;
using System.Drawing;

namespace Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Dosya yollarını ayarlayın
            string projectRootPath = @"C:\Users\Ege Erbilen\Desktop\Projeler\E-commerce\E-Commers Back\Repository\Seeds\Images";
            string[] imagePaths = {
                Path.Combine(projectRootPath, "1.png"),
                Path.Combine(projectRootPath, "2.png"),
                Path.Combine(projectRootPath, "3.png"),
                Path.Combine(projectRootPath, "4.png"),
                Path.Combine(projectRootPath, "5.png"),
                Path.Combine(projectRootPath, "6.png"),
                Path.Combine(projectRootPath, "7.png")
            };

            builder.HasData(
                new Product
                {
                    Id = 1,
                    UserId = 1,
                    CategoryId = 1,
                    Name = "Product 1",
                    Description = "Description 1",
                    Price = 100.0m,
                    Stock = 2,
                    CreatedDate = DateTime.Now,
                    ImageData = ConvertImageToByteArray(imagePaths[0])
                },
                new Product
                {
                    Id = 2,
                    UserId = 1,
                    CategoryId = 1,
                    Name = "Product 2",
                    Description = "Description 1",
                    Price = 200.0m,
                    Stock = 1,
                    CreatedDate = DateTime.Now,
                    ImageData = ConvertImageToByteArray(imagePaths[1])
                },
                new Product
                {
                    Id = 3,
                    UserId = 2,
                    CategoryId = 2,
                    Name = "Product 3",
                    Price = 150.0m,
                    Stock = 4,
                    CreatedDate = DateTime.Now,
                    ImageData = ConvertImageToByteArray(imagePaths[2])
                },
                new Product
                {
                    Id = 4,
                    UserId = 2,
                    CategoryId = 2,
                    Name = "Product 4",
                    Description = "Description 1",
                    Price = 250.0m,
                    Stock = 12,
                    CreatedDate = DateTime.Now,
                    ImageData = ConvertImageToByteArray(imagePaths[3])
                },
                new Product
                {
                    Id = 5,
                    UserId = 3,
                    CategoryId = 3,
                    Name = "Product 5",
                    Description = "Description 1",
                    Price = 300.0m,
                    Stock = 14,
                    CreatedDate = DateTime.Now,
                    ImageData = ConvertImageToByteArray(imagePaths[4])
                }
            );
        }

        private byte[] ConvertImageToByteArray(string imagePath)
        {
            if (!File.Exists(imagePath))
            {
                Console.WriteLine($"File not found: {imagePath}");
                throw new FileNotFoundException($"The file {imagePath} does not exist.");
            }

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (Image image = Image.FromFile(imagePath))
                {
                    // Resim boyutunu küçült
                    using (Bitmap resizedImage = new Bitmap(image, new Size(100, 100)))
                    {
                        resizedImage.Save(memoryStream, ImageFormat.Png);
                    }
                }
                return memoryStream.ToArray();
            }
        }
    }
}
