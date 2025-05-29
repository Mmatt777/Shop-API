using Microsoft.IdentityModel.Tokens;
using Shop.Domain.Entities;
using Shop.Infrastructure.Persistens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Seeders
{
    internal class ShopSeeder(ShopDbContext dbContext) : IShopSeeder
    {
        public async Task Seed()
        {
            if (await dbContext.Database.CanConnectAsync())
                if (!dbContext.Categories.Any())
                {
                    var categories = SetCategories();
                    dbContext.Categories.AddRange(categories);
                    await dbContext.SaveChangesAsync();
                }
        }

        private IEnumerable<Category> SetCategories()
        {
            List<Category> categories = [
                new() {
                    Name = "She",
                    SubCategories = [
                        new() {
                            Name = "Sport Shoes",
                            Products = [
                                new() {
                                    Name = "Sneakers",
                                    Description = "Very comfortable",
                                    Cost = 244.99f,
                                    Count = 566,
                                    IsAvailable = true
                                }
                            ]
                        },
                        new() {
                            Name = "Accessories",
                            Products = [
                                new() {
                                    Name = "Canvas Tote Bag",
                                    Description = "Eco-friendly with printed logo",
                                    Cost = 59.00f,
                                    Count = 140,
                                    IsAvailable = true
                                }
                            ]
                        }
                    ]
                },
                new() {
                    Name = "He",
                    SubCategories = [
                        new() {
                            Name = "Jackets",
                            Products = [
                                new() {
                                    Name = "Leather Jacket",
                                    Description = "Black slim-fit with zipper",
                                    Cost = 349.99f,
                                    Count = 78,
                                    IsAvailable = true
                                }
                            ]
                        },
                        new() {
                            Name = "Shirts",
                            Products = [
                                new() {
                                    Name = "Formal Shirt",
                                    Description = "White cotton, perfect for office",
                                    Cost = 129.99f,
                                    Count = 200,
                                    IsAvailable = true
                                }
                            ]
                        }
                    ]
                },
                new() {
                    Name = "Kids",
                    SubCategories = [
                        new() {
                            Name = "T-Shirts",
                            Products = [
                                new() {
                                    Name = "Cartoon Tee",
                                    Description = "100% cotton, colorful print",
                                    Cost = 39.90f,
                                    Count = 210,
                                    IsAvailable = true
                                }
                            ]
                        }
                    ]
                }
            ];
            return categories;
        }
    }
}
