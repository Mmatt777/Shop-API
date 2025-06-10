using Microsoft.IdentityModel.Tokens;
using Shop.Domain.Entities;
using Shop.Infrastructure.Persistens;
using System.Collections.Generic;


namespace Shop.Infrastructure.Seeders
{
    internal class ShopSeeder(ShopDbContext dbContext) : IShopSeeder
    {
        public async Task Seed()
        {
            if (await dbContext.Database.CanConnectAsync())
                if (!dbContext.Categories.Any())
                {
                    var categories = SetCategory().ToList();
                    var subCategories = SetSubCategories(categories).ToList();
                    var brands = SetBrands(categories, subCategories).ToList();
                    var products = SetProduct(categories, subCategories, brands).ToList();

                    using var transaction = await dbContext.Database.BeginTransactionAsync();

                    dbContext.Categories.AddRange(categories);
                    dbContext.SubCategories.AddRange(subCategories);
                    dbContext.Brands.AddRange(brands);
                    dbContext.Products.AddRange(products);

                    await dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
        }

        public List<Category> SetCategory()
        {
            List<Category> categories = [
                new() { Name = "She" },
                new() { Name = "He" },
                new() { Name = "Kids" } 
            ];
            return categories;
        }

        public List<SubCategory> SetSubCategories(List<Category> categories)
        {
            List<SubCategory> subCategories = [
                new() { Name = "Sport Shoes", Category = categories[0] },
                new() { Name = "Accessories", Category = categories[0] },
                new() { Name = "Jackets", Category = categories[1] },
                new() { Name = "Shirts", Category = categories[1] },
                new() { Name = "T-Shirts", Category = categories[2] },
                new() { Name = "Hats", Category = categories[2] },
                ];
            return subCategories;
        }

        public List<Brand> SetBrands(List<Category> categories, List<SubCategory> subCategories)
        {
            List<Brand> brands = [
                new() { Name = "Nike", Category = categories[0], SubCategory = subCategories[0] },
                new() { Name = "Adidas", Category = categories[0], SubCategory = subCategories[0] },

                new() { Name = "Puma", Category = categories[0], SubCategory = subCategories[1] },
                new() { Name = "Reebok", Category = categories[0], SubCategory = subCategories[1] },

                new() { Name = "UnderArmour", Category = categories[1], SubCategory = subCategories[2] },
                new() { Name = "NewBalance", Category = categories[1], SubCategory = subCategories[2] },

                new() { Name = "Converse", Category = categories[1], SubCategory = subCategories[3] },
                new() { Name = "Vans", Category = categories[1], SubCategory = subCategories[3] },

                new() { Name = "Fila", Category = categories[2], SubCategory = subCategories[4] },
                new() { Name = "Asics", Category = categories[2], SubCategory = subCategories[4] },

                new() { Name = "Skechers", Category = categories[2], SubCategory = subCategories[4] },
                new() { Name = "Mizuno", Category = categories[2], SubCategory = subCategories[4] }
            ];
            return brands;
        }

        public List<Product> SetProduct(List<Category> categories, List<SubCategory> subCategories, List<Brand> brands)
        {
            List<Product> products = 
            [
                new() {
                    Name = "Sneakers Elite",
                    Description = "Ultralight and breathable",
                    Cost = 249.99f,
                    StockQuantity = 200,
                    IsAvailable = true,
                    Category = categories[0],
                    SubCategory = subCategories[0],
                    Brand = brands[0]
                },
                new() {
                    Name = "Runner X",
                    Description = "Cushioned for long-distance running",
                    Cost = 219.50f,
                    StockQuantity = 150,
                    IsAvailable = true,
                    Category = categories[0],
                    SubCategory = subCategories[0],
                    Brand = brands[1]
                },
                new() {
                    Name = "Elegant Scarf",
                    Description = "Lightweight silk scarf",
                    Cost = 79.99f,
                    StockQuantity = 80,
                    IsAvailable = true,
                    Category = categories[0],
                    SubCategory = subCategories[1],
                    Brand = brands[2]
                },
                new() {
                    Name = "Studded Belt",
                    Description = "Leather belt with metal studs",
                    Cost = 129.50f,
                    StockQuantity = 60,
                    IsAvailable = true,
                    Category = categories[0],
                    SubCategory = subCategories[1],
                    Brand = brands[3]
                },
                new() {
                    Name = "Windbreaker Pro",
                    Description = "Lightweight wind-resistant jacket",
                    Cost = 339.00f,
                    StockQuantity = 40,
                    IsAvailable = true,
                    Category = categories[1],
                    SubCategory = subCategories[2],
                    Brand = brands[4]
                },
                new() {
                    Name = "Leather Rider",
                    Description = "Genuine leather motorcycle jacket",
                    Cost = 899.00f,
                    StockQuantity = 25,
                    IsAvailable = true,
                    Category = categories[1],
                    SubCategory = subCategories[2],
                    Brand = brands[5]
                },
                new() {
                    Name = "Oxford Classic",
                    Description = "Slim-fit cotton shirt",
                    Cost = 119.90f,
                    StockQuantity = 70,
                    IsAvailable = true,
                    Category = categories[1],
                    SubCategory = subCategories[3],
                    Brand = brands[6]
                },
                new() {
                    Name = "Chambray Casual",
                    Description = "Lightweight chambray fabric shirt",
                    Cost = 149.50f,
                    StockQuantity = 55,
                    IsAvailable = true,
                    Category = categories[1],
                    SubCategory = subCategories[3],
                    Brand = brands[7]
                },
                new() {
                    Name = "Fun Tee",
                    Description = "Colorful print, soft cotton",
                    Cost = 49.99f,
                    StockQuantity = 120,
                    IsAvailable = true,
                    Category = categories[2],
                    SubCategory = subCategories[4],
                    Brand = brands[8]
                },
                new() {
                    Name = "Cool Graphic",
                    Description = "T-shirt with trendy graphic design",
                    Cost = 54.99f,
                    StockQuantity = 100,
                    IsAvailable = true,
                    Category = categories[2],
                    SubCategory = subCategories[4],
                    Brand = brands[9]
                },
                new() {
                    Name = "Kids Cap",
                    Description = "Adjustable visor cap for kids",
                    Cost = 39.99f,
                    StockQuantity = 140,
                    IsAvailable = true,
                    Category = categories[2],
                    SubCategory = subCategories[4],
                    Brand = brands[10]
                },
                new() {
                    Name = "Sun Guard",
                    Description = "Wide-brimmed sun protection hat",
                    Cost = 59.50f,
                    StockQuantity = 80,
                    IsAvailable = true,
                    Category = categories[2],
                    SubCategory = subCategories[4],
                    Brand = brands[11]
                }
            ];
            return products;
        }
    }

}

