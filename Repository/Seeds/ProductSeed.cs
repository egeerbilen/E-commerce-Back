using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

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
                    Name = "Name 1",
                    Id = 1,
                    UserId = 1,
                    CategoryId = 1,
                    Price = 644.99M,
                    CreatedDate = DateTime.Now,
                    ImageData = ConvertImageToByteArray(imagePaths[0])
                },
                new Product
                {
                    Name = "Name 2",
                    Id = 2,
                    UserId = 1,
                    CategoryId = 1,
                    Price = 1299.99M,
                    CreatedDate = DateTime.Now,
                    ImageData = ConvertImageToByteArray(imagePaths[1])
                },
                new Product
                {
                    Name = "Name 3",
                    Id = 3,
                    UserId = 2,
                    CategoryId = 2,
                    Price = 6219.99M,
                    CreatedDate = DateTime.Now,
                    ImageData = ConvertImageToByteArray(imagePaths[2])
                },
                new Product
                {
                    Name = "Name 4",
                    Id = 4,
                    UserId = 2,
                    CategoryId = 2,
                    Price = 299.99M,
                    CreatedDate = DateTime.Now,
                    ImageData = ConvertImageToByteArray(imagePaths[3])
                },
                new Product
                {
                    Name = "Name 5",
                    Id = 5,
                    UserId = 3,
                    CategoryId = 3,
                    Price = 123.99M,
                    CreatedDate = DateTime.Now,
                    ImageData = ConvertImageToByteArray(imagePaths[4])
                },
                new Product
                {
                    Name = "Name 6",
                    Id = 6,
                    UserId = 3,
                    CategoryId = 3,
                    Price = 89.99M,
                    CreatedDate = DateTime.Now,
                    ImageData = ConvertImageToByteArray(imagePaths[5])
                },
                new Product
                {
                    Name = "Name 7",
                    Id = 7,
                    UserId = 4,
                    CategoryId = 4,
                    Price = 199.99M,
                    CreatedDate = DateTime.Now,
                    ImageData = ConvertImageToByteArray(imagePaths[6])
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
